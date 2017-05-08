using KeptitClient.Models;
using KeptitClient.ViewModels;
using KeptitClient.Persistency;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Handlers
{
    public class SubAreaHandler
    {
        private GreenkeeperViewModel Mwm { get; set; }

        //Constructor
        public SubAreaHandler(GreenkeeperViewModel mwm)
        {
            this.Mwm = mwm;
        }

        public async Task GetSubAreaCollection()
        {
            //Brug foreach hvis LoadSubAreaAsync() i PersistencyService kodes som async:
            foreach (var item in await PersistencyService.LoadSubAreasAsync())
            {
                Mwm.SubAreaCollection.Add(item);
            }
        }
    }
}
