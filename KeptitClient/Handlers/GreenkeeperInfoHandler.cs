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

            //var deldageop =
            //      from t1 in await PersistencyService.LoadGreenkeeperInfoAsync()
            //      where t1.GreenkeeperName != ""
            //      orderby t1.Date descending
            //      group t1 by new { t1.Date, t1.GreenkeeperName }
            //      into dagene
            //      select new
            //      {
            //          D = dagene.Key,
            //          TOver = dagene.Sum(x => x.GivTotalMinutOverarbejde() / 60),
            //          MOver = dagene.Sum(x => x.GivTotalMinutOverarbejde()) % 60,
            //          Timer = dagene.Sum(x => x.GivTotalMinutNormal() / 60),
            //          Minutter = dagene.Sum(x => x.GivTotalMinutNormal() % 60)
            //    };


            //var AlleOpgaverPaaGreenkeeper =
            //    from t2 in deldageop
            //    orderby t2.Timer descending
            //    group t2 by t2.D.GreenkeeperName
            //      into dagene2
            //    select new
            //    {
            //        D = dagene2.Key,
            //        Sammen_Lagt_Timer = dagene2.Sum(x => x.Timer * 60 + x.Minutter) / 60,
            //        Sammen_Lagt_Minutter = dagene2.Sum(x => x.Timer * 60 + x.Minutter) % 60
            //    };
            //Mwm.ListViewSamlet.DataContext = AlleOpgaverPaaGreenkeeper;
            //Mwm.ListViewOpgaverPrDag.DataContext = deldageop;

        }

    }
}
