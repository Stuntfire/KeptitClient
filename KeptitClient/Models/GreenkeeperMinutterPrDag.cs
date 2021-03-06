﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Import;

namespace KeptitClient.Models
{
    public class GreenkeeperMinutterPrDag
    {
        public string GreenkeeperName { get; set; }

        public int Minutterialt { get; set; }

        public DateTime Date { get; set; }

        public GreenkeeperMinutterPrDag()
        {
            DateTime Date = new DateTime();
        }

        // Beregner til overarbejde. Den tager højde for weekend og når man passere 7,4 timer i hverdagen. en dag er 444 minutter i normal timer.
        public int GivTotalMinutOverarbejde()
        {
            decimal totalminutover = Minutterialt;
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
            decimal totalminut = Minutterialt;
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

        public override string ToString()
        {
            return String.Format("{0}.\nMinutter ialt: {1}. \nDato: {2:dd-MM-yy}.", GreenkeeperName, Minutterialt, Date);
        }

    }
}
