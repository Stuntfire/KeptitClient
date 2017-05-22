using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Models
{
    public class Greenkeeper
    {
        #region properties
        public int GreenkeeperID { get; set; }
        public string GreenkeeperName { get; set; }

        #endregion

        public Greenkeeper(int greenId, string greenname)
        {
            this.GreenkeeperID = greenId;
            this.GreenkeeperName = greenname;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", GreenkeeperName, GreenkeeperID);
        }
    }
}
