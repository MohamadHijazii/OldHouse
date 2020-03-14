using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OldHouse.Data;
using OldHouse.Models;
using OldHouse.Other;

namespace OldHouse.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class HandleAlertController : ControllerBase
    {

        public readonly Manager manager;
        private readonly ApplicationDbContext _context;


        public HandleAlertController(ApplicationDbContext context, Manager manager)
        {
            this.manager = manager;
            _context = context;
            List<Machine> machines = _context.Machines.Where(
                m => m.Status == Models.Status.IN_USE 
                ).ToList();
            manager.setAll(machines);
        }

        [HttpPost]
        public async Task<IActionResult> post([FromBody]RTAlert alert)
        {
            int hash = alert.GetHashCode();
            Alert newalert = new Alert();

            newalert.seen = false;
            newalert.Description = $"{alert.text},\n INFO: Glucose: {alert.info.glucose}\n" +
                $"Heart Rate: {alert.info.heartRate}\n Blood Pressure: {alert.info.bloodPressure}" +
                $"\nTemperature: {alert.info.temperature}\n";
            newalert.PatientId = 1;
                newalert.CreatedAt = alert.time;


            await _context.Alerts.AddAsync(newalert);
            await _context.SaveChangesAsync();
            //add an alert to the doctor to see it
            return Ok(hash);
        }

        [HttpGet("check/{id}")]
        public async Task<IActionResult> check1(int id)
        {
            string s = SecurityHelper.getRandomMessage();
            string hash = SecurityHelper.getHash(s);
            RTMachine machine = manager.getMachineWithId(id);
            if(machine == null)
            {
                return BadRequest("No machine with this ID.");
            }
            machine.checkHash = hash;
            return Ok(s);
        }

        [HttpGet("check/{id}/{hash}")]
        public async Task<IActionResult> check2(int id,string hash)
        {
            RTMachine machine = manager.getMachineWithId(id);
            bool b = machine.checkHash.CompareTo(hash) == 0;
            if (b)
            {
                manager.checkMachine(id);
                return Ok("Check is verifyed");
            }
            return BadRequest("Something went wrong!");
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {

            return Ok(manager.machines);
        }

    }
}