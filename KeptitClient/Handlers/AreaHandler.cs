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
    public class AreaHandler
    {
        private MainViewModel Mwm { get; set; }

        //Constructor
        public AreaHandler(MainViewModel mvm)
        {
            this.Mwm = mvm;
        }

        public async Task GetAreaCollection()
        {
            //Brug foreach hvis LoadGreenkeepersAsync() i PersistencyService kodes som async:
            foreach (var item in await PersistencyService.LoadAreasAsync())
            {
                Mwm.AreaCollection.Add(item);
            }
        }

        ////Creates a new Area
        //public void CreateArea()
        //{
        //    Area temp_Area = new Area(Mwm.SelectedArea.AreaID, Mwm.SelectedArea.AreaTitle);
        //    PersistencyService.PostAsJsonTask(temp_Area);
        //}
    }
}
