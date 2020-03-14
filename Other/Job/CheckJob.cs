using OldHouse.Controllers;
using OldHouse.Data;
using OldHouse.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OldHouse.Other
{
    public class CheckJob 
        //: IJob
    {
    //    Manager manager;

    //    ApplicationDbContext _context;
    //    PatientsController p;

    //    public CheckJob(Manager manager,ApplicationDbContext context)
    //    {
    //        this.manager = manager;
    //        _context = context;
    //    }
    //    public async Task Execute(IJobExecutionContext context)
    //    {
    //        Console.WriteLine("Enter");
    //        int m = _context.Machines.Where(c => c.MachineId == 2).FirstOrDefault().MachineId;
    //        Console.WriteLine($"Not Null {m}");
            
    //        List<Int32> ids = manager.getNonCheckedIds();
    //        foreach (int id in ids)
    //        {
    //            manager.machines[0].ischecked = true;
    //            Alert alert = new Alert
    //            {
    //                PatientId = id,
    //                Description = $"Patient {id} 's machine is disconnected!",
    //                CreatedAt = DateTime.Now,
    //                seen = false
    //            };
    //            await _context.Alerts.AddAsync(alert);
    //        }
    //        await _context.SaveChangesAsync();
    //        manager.initializeCheck();
    //    }
    }
}
