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
        private GreenkeeperViewModel Mwm { get; set; }

        public GreenkeeperInfoHandler(GreenkeeperViewModel mwm)
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

        public async Task LoadUpdatedList()
        {
            Mwm.GreenkeeperInfoCollection.Clear();

            //todo Lav den her liste til updatelist
            foreach (var item in await PersistencyService.LoadGreenkeeperInfoAsync())
            {
                if (item.GreenkeeperName == Mwm.SelectedGreenKeeper.GreenkeeperName)
                {
                    Mwm.GreenkeeperInfoCollection.Add(item);
                }
            }
        }
    }
}
