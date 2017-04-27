using KeptitClient.Models;
using KeptitClient.ViewModels;
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

        public ObservableCollection<Area> AreasCollection { get; set; }

        //Constructor
        public AreaHandler(MainViewModel mvm)
        {
            this.Mwm = mvm;
        }

        //Gets all Areas from Database via PersistencyService
        public async Task GetAreas()
        {
            this.AreasCollection = await Persistency.PersistencyService.LoadAreasAsync();

            //Brug foreach hvis LoadAreasAsync() i PersistencyService kodes som async:
            foreach (var item in await Persistency.PersistencyService.LoadAreasAsync())
            {
                this.AreasCollection.Add(item);
            }
        }

        ////Create et nyt Area
        //public void CreateArea()
        //{
        //    Area temp_Area = new Area(Mwm.SelectedArea.AreaID, Mwm.SelectedArea.AreaTitle);
        //    Persistency.PersistencyService.PostAsJsonTask(temp_Area);
        //}
    }
}
