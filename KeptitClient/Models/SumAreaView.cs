using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Models
{
    public class SumAreaView
    {
        public int AreaMinutterIalt { get; set; }

        public DateTime Date { get; set; }

        public string AreaTitle { get; set; }

        

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", AreaMinutterIalt, Date, AreaTitle);
        }
    }
}
