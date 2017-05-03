using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Models
{
    public class SubArea
    {
        #region Properties
        public int SubAreaID { get; set; }
        public string SubAreaTitle { get; set; }
        
        #endregion

        public SubArea(int inSubaAreaId, string inSubAreaTitle)
        {
            this.SubAreaID = inSubaAreaId;
            this.SubAreaTitle = inSubAreaTitle;
        }

        public override string ToString()
        {
            return string.Format("{0}", SubAreaTitle);
        }
    }
}

