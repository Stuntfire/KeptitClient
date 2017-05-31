﻿using System;
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

        //public string SubAreaTitle { get; set; }

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
        // Beregner til overarbejde. Den tager højde for weekend og når man passere 7,4 timer i hverdagen. en dag er 444 minutter i normal timer.
        public int GivTotalMinutOverarbejde()
        {
            totalminutover = Hours * 60 + (Minutes);
            if (Date.DayOfWeek == DayOfWeek.Saturday || Date.DayOfWeek == DayOfWeek.Sunday)
            {
                totalminutover = totalminutover * 1.5M;
            }
            else if (Date.DayOfWeek == DayOfWeek.Monday && totalminutover >= 445 ||
                 Date.DayOfWeek == DayOfWeek.Tuesday && totalminutover >= 445 ||
                 Date.DayOfWeek == DayOfWeek.Wednesday && totalminutover >= 445 ||
                 Date.DayOfWeek == DayOfWeek.Thursday && totalminutover >= 445 ||
                 Date.DayOfWeek == DayOfWeek.Friday && totalminutover >= 445)
            {
                totalminutover = totalminutover - 444M;
                totalminutover = totalminutover * 1.5M;
            }
            else
            {
                totalminutover = 0;
            }

            return (int)totalminutover;
        }

        // beregner for normal timer. En normal dag er 7.4 timer = 444 minutter.
        public int GivTotalMinutNormal()
        {
            decimal totalminut = Hours * 60 + (Minutes);
            if (Date.DayOfWeek == DayOfWeek.Monday && totalminut <= 444 ||
                Date.DayOfWeek == DayOfWeek.Tuesday && totalminut <= 444 ||
                Date.DayOfWeek == DayOfWeek.Wednesday && totalminut <= 444 ||
                Date.DayOfWeek == DayOfWeek.Thursday && totalminut <= 444 ||
                Date.DayOfWeek == DayOfWeek.Friday && totalminut <= 444)
            {
                return (int)totalminut;
            }
            else if (Date.DayOfWeek == DayOfWeek.Monday && totalminut >= 445 ||
                Date.DayOfWeek == DayOfWeek.Tuesday && totalminut >= 445 ||
                Date.DayOfWeek == DayOfWeek.Wednesday && totalminut >= 445 ||
                Date.DayOfWeek == DayOfWeek.Thursday && totalminut >= 445 ||
                Date.DayOfWeek == DayOfWeek.Friday && totalminut >= 445)
            {
                totalminut = 444M;
                return (int)totalminut;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Det er denne override ToString som ListView'et på Greenkeeper siden benytter
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //return $"{GreenkeeperName}\n{AreaTitle}, {GreenTaskTitle}\n{Hours} timer og {Minutes} minutter\n{Date:dd-MM-yy}\nNote: {Notes}";

            return String.Format("{0}. {1}. {2}. {3}. {4} timer. {5:dd-MM-yy} minutter. {6}", GreenkeeperName, AreaTitle, GreenTaskTitle, Hours, Minutes, Date, Notes);

            //return String.Format("{0}. Note: {1}", GreenkeeperName, Notes);
        }

        //public string Summary {
        //    get { return $"{GreenkeeperName}\n{AreaTitle}, {GreenTaskTitle}\n{Hours} timer og {Minutes} minutter\n{Date:dd-MM-yy}\nNote: {Notes}\n"; }
        //}
    }
}
