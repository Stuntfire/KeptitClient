using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Models
{
    public class GreenTask
    {
        public int GreenTaskID { get; set; }
        
        public string GreenTaskTitle { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", GreenTaskTitle);
        }
    }
}
