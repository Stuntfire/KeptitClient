using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Models
{
    public class TimerIaltArea : GreenkeeperInfo
    {
        public override string ToString()
        {
            return $"\nOmråde:  \n{AreaTitle} \n{Hours} timer og {Minutes} minutter \n\n-------------------------------------";
        }
    }
}
