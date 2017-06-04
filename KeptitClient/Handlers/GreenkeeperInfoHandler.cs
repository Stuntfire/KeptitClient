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

            var altInfoListe =
                from i in await PersistencyService.LoadGreenkeeperInfoAsync()
                where i.GreenkeeperName != ""
                orderby i.Date descending
                group i by new { i.GreenkeeperName, i.Date }
                into infoliste
                select new
                {
                    d = infoliste.Key,
                    Name = infoliste.Min(x => x.GreenkeeperName),
                    Data = infoliste.Min(x => x.Date),
                    AreaTitle = infoliste.Min(x => x.AreaTitle),
                    Hours = infoliste.Min(x => x.Hours),
                    Notes = infoliste.Min(x => x.Notes),
                    GreenTaskTitle = infoliste.Min(x => x.GreenTaskTitle),
                    Minutes = infoliste.Min(x => x.Minutes)


                };

            // Viser listen uden {} = og andre unødvændige variabel navne.
            var GreenkeeperinfoListen =
                from b1 in altInfoListe
                orderby b1.d.Date descending
                select new Models.GreenkeeperInfo() { GreenkeeperName = b1.Name, Date = b1.Data, AreaTitle = b1.AreaTitle, Hours = b1.Hours, Notes = b1.Notes, GreenTaskTitle = b1.GreenTaskTitle, Minutes = b1.Minutes };


            //Brug foreach hvis LoadSubAreaAsync() i PersistencyService kodes som async:
            foreach (var item in GreenkeeperinfoListen)
            {
                Mwm.GreenkeeperInfoCollection.Add(item);
            }

            
        }

        public async Task LoadUpdatedList()
        {
            Mwm.GreenkeeperInfoCollection.Clear();

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
