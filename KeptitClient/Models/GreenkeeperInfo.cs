using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Text;

namespace KeptitClient.Models
{
    public class GreenkeeperInfo
    {
        #region Properties
        public int FinishedTasksID { get; set; }

        public int GreenkeeperID { get; set; }

        public string GreenkeeperName { get; set; }

        public string AreaTitle { get; set; }

        public string GreenTaskTitle { get; set; }

        public int Hours { get; set; }

        public int Minutes { get; set; }

        public DateTime Date { get; set; }

        public string Notes { get; set; }

        public decimal totalminutover { get; set; }

        #endregion
        public GreenkeeperInfo()
        {

        }

        public GreenkeeperInfo(int hours, int minutes)
        {
            this.Hours = hours;
            this.Minutes = minutes;
        }
        

        /// <summary>
        /// Det er denne override ToString som ListView'et på Greenkeeper siden benytter
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("{0}. {1}. {2}. {3}. {4} timer. {5:dd-MM-yy} minutter. {6}", GreenkeeperName, AreaTitle, GreenTaskTitle, Hours, Minutes, Date, Notes);
            
        }
        
    }
}
