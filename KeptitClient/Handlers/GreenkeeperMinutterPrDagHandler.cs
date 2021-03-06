﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using KeptitClient.Models;
using KeptitClient.ViewModels;
using KeptitClient.Persistency;

namespace KeptitClient.Handlers
{
    public class GreenkeeperMinutterPrDagHandler
    {
        private MainViewModel Mwm { get; set; }

        public GreenkeeperMinutterPrDagHandler(MainViewModel mwm)
        {
            this.Mwm = mwm;
        }
        // Henter alle færdige opgaver for en dag pr Greenkeeper, med navn alle minutter og dato.
        public async Task GetGreenkeeperMinutterPrDagCollection()
        {
            //Brug foreach hvis LoadSubAreaAsync() i PersistencyService kodes som async:
            foreach (var item in await PersistencyService.LoadGreenkeeperMinutterPrDagAsync())
            {
                Mwm.GreenkeeperMinutterPrDagCollection.Add(item);
            }
        }

        // tester en opdateret liste på admin side, så datepicker opdatere lïsten.
        public async Task LoadUpdatedListAllAdmin()
        {
            Mwm.TimerIaltCollection.Clear();

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


            // Beregner samlet timer for en greenkeeper, kan filtreres ud fra dato.
            var AlleOpgaverPaaGreenkeeper =
                from t2 in deldageop
                where t2.D.GreenkeeperName != ""
                orderby t2.Timer descending
                group t2 by new { t2.D.GreenkeeperName, t2.D.Date }
                into dagene2
                select new
                {
                    D = dagene2.Key,
                    Timer = dagene2.Sum(x => x.Timer * 60 + x.Minutter) / 60,
                    Minutter = dagene2.Sum(x => x.Timer * 60 + x.Minutter) % 60,
                    n = Environment.NewLine,
                    TOver2 = dagene2.Sum(x => x.TOver),
                    MOver2 = dagene2.Sum(x => x.MOver),
                    navn = dagene2.Min(x => x.D.GreenkeeperName)
                };

            // Viser listen uden {} = og andre unødvændige variabel navne.
            var timerialtprmandformat =
                from b1 in AlleOpgaverPaaGreenkeeper
                orderby b1.D.Date descending 
                select new Models.TimerIalt() { GreenkeeperName = b1.navn, Timer = b1.Timer, Minutter = b1.Minutter, TimerOver = b1.TOver2, MinutterOver = b1.MOver2, Date = b1.D.Date };
          

            foreach (var item in timerialtprmandformat)
            {
                if (item.Date.Month == Mwm.SelectedDateAdmin.Date.Month && item.Date.Year == Mwm.SelectedDateAdmin.Year)
                {
                    Mwm.TimerIaltCollection.Add(item);
                }
            }

            Mwm.ListViewSamlet.DataContext = timerialtprmandformat;

        }

        // Beregner for hver greenkeeper der viser navn,timer og antal minutter på normaal timer og overarbejde. Sortere på dato, nyeste øverst.
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

            var timerprdagprmandformat =
                from e1 in deldageop
                select new Models.TimerPrDagPrMand() { GreenkeeperName = e1.D.GreenkeeperName, Date = e1.D.Date, Timer = e1.Timer, Minutter = e1.Minutter, TimerOver = e1.TOver, MinutterOver = e1.MOver };

            Mwm.ListViewOpgaverPrDag.DataContext = timerprdagprmandformat;

        }
    }
}

