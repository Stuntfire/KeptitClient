using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Models
{
    public class TimerPrDagPrMand : GreenkeeperInfo
    {
        public int TimerOver { get; set; }
        public int MinutterOver { get; set; }
        public int Timer { get; set; }
        public int Minutter { get; set; }


        public override string ToString()
        {
            return string.Format("{0} {1}{2:dd-MM-yy}{3}Normal Timer:{4}Timer: {5}  Minutter: {6}{7}Overarbejdstimer: {8}Timer: {9} Minutter: {10}  {11}"
                , GreenkeeperName, Environment.NewLine, Date, Environment.NewLine,Environment.NewLine,  Timer, Minutter,Environment.NewLine, Environment.NewLine, TimerOver,MinutterOver,Environment.NewLine); 
        }

    }
}
