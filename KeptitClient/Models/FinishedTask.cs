using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Models
{
    public class FinishedTask
    {
        #region properties
        public int FinishedTasksID { get; set; }

        public int AreaID { get; set; }

        public int GreenTaskID { get; set; }

        public int SubAreaID { get; set; }

        public int GreenkeeperID { get; set; }

        public DateTime Date { get; set; }

        public int Hours { get; set; }

        public int Minutes { get; set; }

        public string Notes { get; set; }

        #endregion

        public FinishedTask(int AreaID, int GreenTaskId, int GreenkeeperID, DateTime date, int hours, int minutes, string note)
        {
            this.AreaID = AreaID;
            this.GreenTaskID = GreenTaskId;
            this.GreenkeeperID = GreenkeeperID;
            this.Date = date;
            this.Minutes = minutes;
            this.Hours = hours;
            this.Notes = note;
        }

        public override string ToString()
        {
            //return $"Nr.: {FinishedTasksID}. {AreaID}. {GreenTaskID}. {GreenkeeperID}. {Date:dd-MM-yy}. {Hours} timer. {Minutes} minutter. {Notes}\n";

            return String.Format("Nr.: {0}. {1}. {2}. {3}. {4}. {5} timer og {6} minutter. {7}\n", FinishedTasksID, AreaID, GreenTaskID, GreenkeeperID, Date, Hours, Minutes, Notes);
        }
    }
}
