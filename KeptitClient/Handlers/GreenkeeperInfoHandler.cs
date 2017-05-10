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

        // Beregner for hver greenkeeper der viser navn,timer og antal minutter. Flest timer øverst.
        public async Task GetGreenInfoSortedList()
        {

          var deldageop =
                from t1 in await PersistencyService.LoadGreenkeeperInfoAsync()
                orderby t1.Date descending
                group t1 by new { t1.Date, t1.GreenkeeperName }
                into dagene
                select new
                { 
                    Datoen = dagene.Key,
                    Timer = dagene.Sum(x => x.Hours),
                    Minutter = dagene.Sum(x => x.Minutes),
                    Status = (dagene.Sum(x => x.Hours) == 7 ? "Normal Timer" : (dagene.Sum(x => x.Minutes) == 60 ? "60 minutter" : (dagene.Count() == 1 ? "En opgave" : "Flere opgaver")))
                };
           Mwm.ListViewSamlet.DataContext = deldageop;
        }

    }
}
