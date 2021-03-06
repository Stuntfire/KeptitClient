﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Models
{
    public class TimerIalt : GreenkeeperInfo
    {
        public int TimerOver { get; set; }
        public int MinutterOver { get; set; }
        public int Timer { get; set; }
        public int Minutter { get; set; }


        public override string ToString()
        {
            return string.Format("{0} {1} {2}Normal Timer:{3}Timer: {4}  Minutter: {5}{6}Overarbejdstimer: {7}Timer: {8} Minutter: {9} {10}{11:dd-MM-yy} {12}-------------------------------"
                , GreenkeeperName, Environment.NewLine, Environment.NewLine, Environment.NewLine, Timer, Minutter, Environment.NewLine, Environment.NewLine, TimerOver, MinutterOver, Environment.NewLine, Date, Environment.NewLine);
        }
    }
}
