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
        private GreenkeeperViewModel Mwm { get; set; }

        //Constructor
        public AreaHandler(GreenkeeperViewModel mvm)
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

        // Viser i hvilke område der er brugt flest timer på siden Adminareas. Flest timer øverst.
        public async Task VisOmraader()
        {
            var areasdone =
                from a in await PersistencyService.LoadGreenkeeperInfoAsync()
                group a by a.AreaTitle
                into omraaederne
                select new
                {
                    //todo Minut-beregneren virker ikke helt korrekt
                    Område = omraaederne.Key,
                    Timer = omraaederne.Sum(x => x.GetSumTasksHours() / 60),
                    Min = omraaederne.Sum(x => x.GetSumTasksHours() % 60)
                };

            var areassamlet =
                from a2 in areasdone
                orderby a2.Timer descending
                select a2;

            Mwm.ListViewOmraader.DataContext = areassamlet;
        }


        ////Creates a new Area
        //public void CreateArea()
        //{
        //    Area temp_Area = new Area(Mwm.SelectedArea.AreaID, Mwm.SelectedArea.AreaTitle);
        //    PersistencyService.PostAsJsonTask(temp_Area);
        //}
    }
}
