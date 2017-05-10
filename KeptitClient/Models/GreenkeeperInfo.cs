using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Models
{
    public class GreenkeeperInfo
    {
        #region Properties
        public int FinishedTasksID { get; set; }

        public int GreenkeeperID { get; set; }

        public string GreenkeeperName { get; set; }

        public string AreaTitle { get; set; }

        public string SubAreaTitle { get; set; }

        public string GreenTaskTitle { get; set; }

        public int Hours { get; set; }

        public int Minutes { get; set; }

        public DateTime Date { get; set; }

        public string Notes { get; set; }

        #endregion

        public int GivTotalMinut()
        {
            decimal totalminut = Hours * 60 + (Minutes);
            if (Date.DayOfWeek == DayOfWeek.Saturday || Date.DayOfWeek == DayOfWeek.Sunday)
            {
                 totalminut = totalminut * 1.5M;
            }
            return (int) totalminut;


        }

        public override string ToString()
        {
            return string.Format("{0}. {1}. {2}. {3}. {4}. {5}. {6}. {7}.", GreenkeeperName, AreaTitle, SubAreaTitle, GreenTaskTitle, Hours, Minutes, Date, Notes);
        }
    }
}
