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

        public int GreenTaskID { get; set; }

        public int SubAreaID { get; set; }

        public int GreenkeeperID { get; set; }

        public DateTime Date { get; set; }

        public int Hours { get; set; }

        public int Minutes { get; set; }

        public string Note { get; set; }

        public FinishedTask(int AreaID, int GreenTaskId, int SubAreaID, int GreenkeeperID, DateTime date, int hours, int minutes, string note)
        {
            this.AreaID = AreaID;
            this.GreenTaskID = GreenTaskId;
            this.SubAreaID = SubAreaID;
            this.GreenkeeperID = GreenkeeperID;
            this.Date = date;
            this.Minutes = minutes;
            this.Hours = hours;
            this.Note = note;
        }

        public override string ToString()
        {
            return string.Format("Nr {0}. {1}. {2}. {3}. {4}. {5}. {6}. {7}.", FinishedTasksID, AreaID, GreenTaskID,SubAreaID,GreenkeeperID,Date,Hours,Minutes);
        }
    }
}
