using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHouse.Other
{
    public class SecurityHelper
    {
        public static string getHash(string s)
        {
            StringBuilder hash = new StringBuilder();
            char[] t = s.ToCharArray();
            int n = 65;
            int i = 0;
            for (i = 0; i < t.Length; i++)
            {
                if (i % 4 != 0) continue;
                n = n + t[i];
                n = n % 128;
                hash.Append(n);
                if (i == 40) break;
            }
            return hash.ToString();
        }

        public static string getRandomMessage()
        {
            StringBuilder s = new StringBuilder("");
            Random rand = new Random();
            for (int i = 0; i < 8; i++)
            {
                int n = rand.Next(0, 15);
                string hexa = n.ToString("X");
                s.Append(hexa[0]);
            }
            return s.ToString();
        }


    }
}
