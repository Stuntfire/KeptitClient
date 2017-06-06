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

        public async Task LoadUpdatedList()
        {
            Mwm.GreenkeeperInfoCollection.Clear();

            var OrderTasksByDate =
                from o in await PersistencyService.LoadGreenkeeperInfoAsync()
                orderby o.Date descending
                select o;

            foreach (var item in OrderTasksByDate)
            {
                if (item.GreenkeeperName == Mwm.SelectedGreenKeeper.GreenkeeperName)
                {
                    Mwm.GreenkeeperInfoCollection.Add(item);
                }
            }
        }
    }
}
