using OldHouse.Data;
using OldHouse.Other;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OldHouse.Models
{
    public class Machine
    {
        [Key]
        public int MachineId { get; set; }

        [Range(0,100)]
		public int Battery { get; set; }

        public Status Status { get; set; }

        public string SerialNumber
        {
            get { return "Machine #" + ' ' + MachineId; }
            set { }
        }

        public Patient Patient { get; set; }

        public RTMachine getRTMachine()
        {
            RTMachine machine = new RTMachine
            {
                id = this.MachineId,
                ischecked = false,

                alerts = new List<RTAlert>()
            };

            if (Patient != null)
            {
                machine.user_id = Patient.PatientId;
            }
            else
            {
                machine.user_id = 1;
            }
            return machine;

        }
    }

   public enum Status
    {
        IN_USE = 1,
        AVAILABLE = 2,
        OUT_OF_SERVICE = 3
    }
}
