using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldHouse.Other
{
    public class RTMachine : ICloneable
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public bool ischecked {get;set;}
        public List<RTAlert> alerts { get; set; }

        public string checkHash { get; set; }



        public object Clone()
        {
            RTMachine machine = new RTMachine();
            machine.ischecked = false;
            machine.alerts = new List<RTAlert>();
            return machine;
        }


    }
}
