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

        ////Gets all SubAreas from Database via PersistencyService
        //public async Task GetSubAreas()
        //{
        //    ////hvis async Task
        //    //this.SubAreasCollection = await PersistencyService.LoadSubAreasAsync(); 
        //    this.SubAreasCollection = PersistencyService.LoadSubAreasAsync();

        //    //hvis async Task
        //    foreach (SubArea item in /*await*/ PersistencyService.LoadSubAreasAsync())
        //    {
        //        this.SubAreasCollection.Add(item);
        //    }
        //}
    }
}
