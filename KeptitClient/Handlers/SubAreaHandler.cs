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
        private MainViewModel Mwm { get; set; }

        public ObservableCollection<SubArea> SubAreasCollection { get; set; }

        //Constructor
        public SubAreaHandler(MainViewModel mwm)
        {
            this.Mwm = mwm;
        }

        public async Task GetSubAreaCollection()
        {
            //Brug foreach hvis LoadSubAreaAsync() i PersistencyService kodes som async:
            foreach (var item in await PersistencyService.LoadGreenkeeperAsync())
            {
             //Mwm.SubAreaCollection.Add(item);
            }
        }
    }
}
