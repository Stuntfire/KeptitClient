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
    public class GreenkeeperHandler
    {
        private MainViewModel Mwm { get; set; }

        public ObservableCollection<GreenKeeper> GreenkeepersCollection { get; set; }

        //Constructor
        public GreenkeeperHandler(MainViewModel mwm)
        {
            this.Mwm = mwm;
        }

        ////Gets all Greenkeepers from Database via PersistencyService
        //public async Task GetGreenkeepers()
        //{
        //    this.GreenkeepersCollection = await PersistencyService.LoadGreenkeepersAsync();

        //    //Brug foreach hvis LoadGreenkeepersAsync() i PersistencyService kodes som async:
        //    foreach (var item in await PersistencyService.LoadGreenkeepersAsync())
        //    {
        //        this.GreenkeepersCollection.Add(item);
        //    }
        //}

        ////Creates a new Greenkeeper
        //public void CreateGreenkeeper()
        //{
        //    GreenKeeper tempGreenkeeper = new GreenKeeper(Mwm.SelectedGreenKeeper.GreenkeeperID, Mwm.SelectedGreenKeeper.GreenkeeperName);
        //    PersistencyService.PostGreenkeeperAsJsonAsync(tempGreenkeeper);
        //}
    }
}
