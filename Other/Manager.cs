using OldHouse.Data;
using OldHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldHouse.Other
{
    public class Manager
    {
        public List<RTMachine> machines { get; private set; }    //ids of all the machines
                                                                 //public List<Int32> toCheck { get; private set; }    //ids of check machine
                                                                 //private readonly ApplicationDbContext context;

        /*
         *in the machines we have all the ids of machines in use 
         * ids of machines toCkeck are in toCheck
         * every time a machine sends the check get request
         * we remove its id from toCkeck
         * at the end we send alert for machines that have not check
         * and we reinitialize toCheck list
         */
        private bool done = false;



        public Manager()
        {
            machines = new List<RTMachine>();
            initializeCheck();
        }

        public void setAll(List<Machine> _machines)
        {
            if (done) return;
            foreach(Machine m in _machines)
            {
                machines.Add(m.getRTMachine());
            }
            done = true;
        }

        public RTMachine getMachineWithId(int id)
        {
            foreach (RTMachine m in machines)
            {
                if (m.id == id)
                {
                    return m;
                }
            }
            return null;
        }

        public void addNewMachine(RTMachine m) => machines.Add(m);

        public void removeMachine(int id)
        {
            machines.Remove(getMachineWithId(id));
        }

        public void checkMachine(int id)
        {
            getMachineWithId(id).ischecked = true;

        }

        public List<Int32> getNonCheckedIds()
        {
            List<Int32> ids = new List<int>();
            foreach(RTMachine machine in machines)
            {
                if (!machine.ischecked) { ids.Add(machine.id); }
            }
            return ids;
        } 

        public void initializeCheck()
        {
            foreach(var m in machines)
            {
                m.ischecked = false;
            }
        }
    }
}
