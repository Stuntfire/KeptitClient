using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Models
{
    public class Area
    {
        public int AreaID { get; set; }
        public string AreaTitle { get; set; }

        public Area(int in_areaid, string in_areatitle)
        {
            this.AreaID = in_areaid;
            this.AreaTitle = in_areatitle;
        }

        public override string ToString()
        {
            return $"{AreaTitle}";
        }
    }
}
