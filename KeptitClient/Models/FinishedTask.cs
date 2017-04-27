using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Models
{
    public class FinishedTask
    {
        public int FinishedTasksID { get; set; }

        public int AreaID { get; set; }

        public int? TaskID { get; set; }

        public int SubAreaID { get; set; }

        public int GreenkeeperID { get; set; }

        public DateTime Date { get; set; }

        public int Hours { get; set; }

        public int Minutes { get; set; }

        public FinishedTask()
        {

        }
    }
}
