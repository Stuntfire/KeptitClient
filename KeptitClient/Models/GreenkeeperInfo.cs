using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Models
{
    public class GreenkeeperInfo
    {
        public string GreenkeeperName { get; set; }
        
        public string AreaTitle { get; set; }

      
        public string SubAreaTitle { get; set; }

       
        public string GreenTaskTitle { get; set; }

      
        public int Hours { get; set; }

      
        public int Minutes { get; set; }

    
        public DateTime Date { get; set; }

        public string Notes { get; set; }
    }
}
