using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldHouse.Other
{
    public class RTAlertInfo
    {
        public float glucose { get; set; }
        public float heartRate { get; set; }
        public float bloodPressure { get; set; }
        public float temperature { get; set; }

        public override int GetHashCode()
        {
            return (int)glucose * 5 + (int)heartRate * 7 + (int)bloodPressure * 11 + (int)temperature * 13;
        }
    }
}
