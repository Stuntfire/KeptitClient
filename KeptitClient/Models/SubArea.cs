using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Models
{
    public class SubArea
    {

        public int SubAreaID { get; set; }
        public string SubAreaTitle { get; set; }

        public SubArea(int inSubaAreaId, string inSubAreaTitle)
        {
            this.SubAreaID = inSubaAreaId;
            this.SubAreaTitle = inSubAreaTitle;
        }

        public override string ToString()
        {
            return string.Format("Nr {0}. {1}.", SubAreaID, SubAreaTitle);
        }
    }
}

