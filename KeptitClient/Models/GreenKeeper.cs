using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Models
{
    public class Greenkeeper
    {
        public int GreenkeeperID { get; set; }
        public string GreenkeeperName { get; set; }

        public Greenkeeper(int inID, string ingreenkeeperid)
        {
            this.GreenkeeperID = inID;
            this.GreenkeeperName = ingreenkeeperid;
        }

        public override string ToString()
        {
            return string.Format("{0}.", GreenkeeperName);
        }
    }
}
