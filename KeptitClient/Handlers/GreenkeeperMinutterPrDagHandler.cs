using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using KeptitClient.ViewModels;
using KeptitClient.Persistency;

namespace KeptitClient.Handlers
{
    public class GreenkeeperMinutterPrDagHandler
    {
        private GreenkeeperViewModel Mwm { get; set; }

        public GreenkeeperMinutterPrDagHandler(GreenkeeperViewModel mwm)
        {
            this.Mwm = mwm;
        }
        //Gets all Tasks from Database via PersistencyService
        public async Task GetGreenkeeperMinutterPrDagCollection()
        {
            //Brug foreach hvis LoadSubAreaAsync() i PersistencyService kodes som async:
            foreach (var item in await PersistencyService.LoadGreenkeeperMinutterPrDagAsync())
            {
                Mwm.GreenkeeperMinutterPrDagCollection.Add(item);
            }
        }


        // Beregner for hver greenkeeper der viser navn,timer og antal minutter. Flest timer øverst.
        public async Task GetGreenkeeperMinutterPrDagSortedList()
        {

            var deldageop =
                  from t1 in await PersistencyService.LoadGreenkeeperMinutterPrDagAsync()
                  where t1.GreenkeeperName != ""
                  orderby t1.Date descending
                  group t1 by new { t1.Date, t1.GreenkeeperName }
                  into dagene
                  select new
                  {
                      D = dagene.Key,
                      TOver = dagene.Sum(x => x.GivTotalMinutOverarbejde() / 60),
                      MOver = dagene.Sum(x => x.GivTotalMinutOverarbejde()) % 60,
                      Environment.NewLine,
                      Timer = dagene.Sum(x => x.GivTotalMinutNormal() / 60),
                      Minutter = dagene.Sum(x => x.GivTotalMinutNormal() % 60)
                  };

            var testnyliste1 =
                from e1 in deldageop
                select new Models.TimerPrDagPrMand() { GreenkeeperName = e1.D.GreenkeeperName, Date = e1.D.Date, Timer = e1.Timer, Minutter = e1.Minutter,TimerOver = e1.TOver,MinutterOver = e1.MOver};

            //var testnyliste =
            //    from e1 in deldageop
            //    group e1 by e1.D
            //    into testen
            //    select new
            //    {
            //        Navn = testen.Min(x => x.D.GreenkeeperName),
            //        Dag = testen.Min(x => x.D.Date.Day),
            //        Måned = testen.Min(x => x.D.Date.Month),
            //        År = testen.Min(x => x.D.Date.Year),
            //        n = Environment.NewLine,
            //        Timer = testen.Min(x => x.Timer),
            //        Minutter = testen.Min(x => x.Minutter),
            //        TimerO = testen.Min(x => x.TOver),
            //        MinutterO = testen.Min(x => x.MOver),
            //        n2 = Environment.NewLine,
            //    };

            //foreach (var t in testnyliste)
            //{
            //    t.Navn + t.Dag + t.Måned + t.År
            //} 

            var AlleOpgaverPaaGreenkeeper =
                from t2 in deldageop
                orderby t2.Timer descending
                group t2 by t2.D.GreenkeeperName
                  into dagene2
                select new
                {
                    D = dagene2.Key,
                    Timer = dagene2.Sum(x => x.Timer * 60 + x.Minutter) / 60,
                    Minutter = dagene2.Sum(x => x.Timer * 60 + x.Minutter) % 60,
                    n = Environment.NewLine,
                    TOver2 = dagene2.Sum(x => x.TOver),
                    MOver2 = dagene2.Sum(x => x.MOver)
                };
            Mwm.ListViewSamlet.DataContext = AlleOpgaverPaaGreenkeeper;
            Mwm.ListViewOpgaverPrDag.DataContext = testnyliste1;

        }
    }
}

