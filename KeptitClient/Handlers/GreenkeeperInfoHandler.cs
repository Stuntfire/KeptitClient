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

        //Henter alle opgave-informationer om hver Greenkeeper fra FinishedTask-tabellen, via PersistencyService.
        public async Task GetGreenTaskInfoCollection()
        {
            Mwm.GreenkeeperInfoCollection.Clear();

            var OrderByDate =
                from obd in await PersistencyService.LoadGreenkeeperInfoAsync()
                orderby obd.Date descending
                select obd;

            foreach (var item in OrderByDate)
            {
                Mwm.GreenkeeperInfoCollection.Add(item);
            }
        }

        //Sorterer GreenkeeperInfoCollection, så man kun får opgaver vist der er udført af den greenkeeper man vælger i combobox'en
        public async Task LoadUpdatedList()
        {
            Mwm.GreenkeeperInfoCollection.Clear();

            var OrderTasksByDateForSelectedGreenkeeper =
                from obd in await PersistencyService.LoadGreenkeeperInfoAsync()
                orderby obd.Date descending
                select obd;

            foreach (var item in OrderTasksByDateForSelectedGreenkeeper)
            {
                if (item.GreenkeeperName == Mwm.SelectedGreenKeeper.GreenkeeperName)
                {
                    Mwm.GreenkeeperInfoCollection.Add(item);
                }
            }
        }
    }
}
