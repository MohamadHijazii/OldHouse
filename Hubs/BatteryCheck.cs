using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using OldHouse.Data;
using OldHouse.Models;
using OldHouse.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldHouse.Hubs
{
    public class BatteryCheck : Hub
    {
        private readonly ApplicationDbContext _context;
        private readonly Manager manager;

        public BatteryCheck(ApplicationDbContext context,Manager manager)
        {
            _context = context;
            this.manager = manager;
        }

        #region Methods
        /// <summary>
        /// Call this method every 1 min to decrease the battery level for machines that are IN USE
        /// </summary>
        /// <returns></returns>
        public async Task Check()
        {
            var machines = await _context.Machines.ToListAsync();

            for (int i = 0; i < machines.Count; i++)
            {
                if (machines[i].Status == Status.IN_USE)
                {
                    if(machines[i].Battery <= 40)
                    {
                        machines[i].Status = Status.OUT_OF_SERVICE;
                    }
                    else
                    {
                    machines[i].Battery--;
                    }
                }
            }
            await _context.SaveChangesAsync();
            await Clients.All.SendAsync("batteryCheckk", machines);
        }


        public async Task CheckPatientsBatteryMachineStatus()
        {
            var BatteryBelow50 = new List<string>();
            var patients = await _context.Patients.Include(m=>m.Machine).Where(m => m.Machine.Battery <= 60).ToListAsync();
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Machine.Status == Status.IN_USE)
                {
                    if (patients[i].Machine.Battery <= 60)
                    {
                        patients[i].Machine.Status = Status.OUT_OF_SERVICE;
                        var errorMsg = patients[i].DisplayName + " 's Machine have battery low";
                        BatteryBelow50.Add(errorMsg);
                        _context.Alerts.Add(new Alert() { Level = "Battery", PatientId = patients[i].PatientId, Description = errorMsg });
                    }
                }
            }
            await _context.SaveChangesAsync();
            await Clients.All.SendAsync("patientsBatteryCheckk", BatteryBelow50);
        }


        public async Task CheckPatientRecords()
        {
            var BadPatients = new List<string>();
            var alerts = _context.Alerts.Where(a => a.seen == false);
            foreach (Alert alert in alerts)
            {
                BadPatients.Add($"{alert.Patient.DisplayName} is in danger !");
            }
            await Clients.All.SendAsync("patientRecordsCheckk", BadPatients);
        }

        public async Task getNonChecked()
        {
            var nonChecked = new List<string>();
            List<Int32> ids = manager.getNonCheckedIds();
            foreach(int id in ids)
            {
                nonChecked.Add($"Machine with id: {id} is disconnected!");
            }
            //the list is ready to be sent 
            //do this every 10 sec in testing
        }


        #endregion
    }
}
