using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeptitClient.Persistency;
using KeptitClient.ViewModels;

namespace KeptitClient.Handlers
{
    public class GreenkeeperInfoHandler
    {

        private MainViewModel Mwm { get; set; }

        public GreenkeeperInfoHandler(MainViewModel mwm)
        {
            this.Mwm = mwm;
        }

        //Gets all Tasks from Database via PersistencyService
        public async Task GetGreenTaskInfoCollection()
        {
            //Brug foreach hvis LoadSubAreaAsync() i PersistencyService kodes som async:
            foreach (var item in await PersistencyService.LoadGreenkeeperInfoAsync())
            {
                Mwm.GreenkeeperInfoCollection.Add(item);
            }
        }
    }
}
