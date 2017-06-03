using KeptitClient.Models;
using KeptitClient.ViewModels;
using KeptitClient.Persistency;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Handlers
{
    public class AreaHandler
    {
        private MainViewModel Mwm { get; set; }

        //Constructor
        public AreaHandler(MainViewModel mvm)
        {
            this.Mwm = mvm;
        }

        public async Task GetAreaCollection()
        {
            //Brug foreach hvis LoadGreenkeepersAsync() i PersistencyService kodes som async:
            foreach (var item in await PersistencyService.LoadAreasAsync())
            {
                Mwm.AreaCollection.Add(item);
            }
        }

        // Samlet timer på områder, uafhængig af Greenkeeper.. Flest timer øverst.
        public async Task VisOmraader()
        {
            var areasdone =
                from a in await PersistencyService.LoadSumAreaViewAsync()
                orderby a.AreaMinutterIalt descending
                group a by a.AreaTitle
                into omraaederne
                select new
                {
                    D = omraaederne.Key,
                    Timer = omraaederne.Sum(x => x.AreaMinutterIalt) / 60,
                    Minutter = omraaederne.Sum(x => x.AreaMinutterIalt) % 60
                };

            // Viser listen uden {} = og andre unødvændige variabel navne.
            var timerialtarea =
                from o1 in areasdone
                select new Models.TimerIaltArea() { AreaTitle = o1.D, Hours = o1.Timer, Minutes = o1.Minutter };


            Mwm.ListViewOmraader.DataContext = timerialtarea;
        }
        
    }
}
