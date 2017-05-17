using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Models
{
    public class SumTaskDateView
    {
        public int TaskMinutesTotal { get; set; }

        public DateTime Date { get; set; }

        public string GreenTaskTitle { get; set; }
    }
}
