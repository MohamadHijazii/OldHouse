using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldHouse.Other
{
    public class RTAlert
    {
        public int machine_id { get; set; }
        public string text { get; set; }
        public alertType type { get; set; }
        public DateTime time { get; set; }
        public RTAlertInfo info { get; set; }


        public override int GetHashCode()
        {
            return info.GetHashCode();
        }
    }

    public enum alertType
    {
        Danger,
        Battery,
        Check
    }

    
}
