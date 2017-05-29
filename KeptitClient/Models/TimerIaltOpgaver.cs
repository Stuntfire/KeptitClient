using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KeptitClient.Models
{
    public class TimerIaltOpgaver : GreenkeeperInfo
    {


        public override string ToString()
        {
            return $"\nOpgave:  \n{GreenTaskTitle} \n{Hours} timer og {Minutes} minutter \n\n-------------------------------------";
        }
    }
}
