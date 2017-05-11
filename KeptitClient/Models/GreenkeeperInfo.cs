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

        public int GivTotalMinutOverarbejde()
        {
            decimal totalminuthelligdage = Hours * 60 + (Minutes);
            decimal totalminutoverarbejdetimer = Hours * 60 + (Minutes);
            if (Date.DayOfWeek == DayOfWeek.Saturday || Date.DayOfWeek == DayOfWeek.Sunday)
            {
                totalminuthelligdage = totalminuthelligdage * 1.5M;

            }
            else if (Date.DayOfWeek == DayOfWeek.Monday ||
                 Date.DayOfWeek == DayOfWeek.Tuesday ||
                 Date.DayOfWeek == DayOfWeek.Wednesday ||
                 Date.DayOfWeek == DayOfWeek.Thursday ||
                 Date.DayOfWeek == DayOfWeek.Friday &&
                 totalminutoverarbejdetimer >= 444M)
            {
                totalminutoverarbejdetimer = (totalminutoverarbejdetimer) * 1.5M;
            }
            return (int)totalminuthelligdage + ((int)totalminutoverarbejdetimer - 444);

        }

        public int GivTotalMinutNormalTimer()
        {
            decimal totalminutnormaltimer = Hours * 60 + (Minutes);
            if (Date.DayOfWeek == DayOfWeek.Monday ||
                Date.DayOfWeek == DayOfWeek.Tuesday ||
                Date.DayOfWeek == DayOfWeek.Wednesday ||
                Date.DayOfWeek == DayOfWeek.Thursday ||
                Date.DayOfWeek == DayOfWeek.Friday &&
                totalminutnormaltimer <= 444M)
            {
                totalminutnormaltimer = totalminutnormaltimer * 1;
            }
            return (int)totalminutnormaltimer;
        }

        public override string ToString()
        {
            return string.Format("{0}. {1}. {2}. {3}. {4}. {5}. {6}. {7}.", GreenkeeperName, AreaTitle, SubAreaTitle, GreenTaskTitle, Hours, Minutes, Date, Notes);
        }
    }
}
