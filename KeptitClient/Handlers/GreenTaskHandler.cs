using KeptitClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using KeptitClient.Persistency;
using System.Threading.Tasks;

namespace KeptitClient.Handlers
{
    public class GreenTaskHandler
    {
        private MainViewModel Mwm { get; set; }

        //public ObservableCollection<Tasks> TasksCollection { get; set; }

        public GreenTaskHandler(MainViewModel mwm)
        {
            this.Mwm = mwm;
        }

        //Gets all Tasks from Database via PersistencyService
        public async Task GetGreenTaskCollection()
        {
            //Brug foreach hvis LoadSubAreaAsync() i PersistencyService kodes som async:
            foreach (var item in await PersistencyService.LoadGreenTaskAsync())
            {
                Mwm.GreenTaskCollection.Add(item);
            }
        }
    }
}
