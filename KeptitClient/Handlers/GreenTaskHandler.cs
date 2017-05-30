using KeptitClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using KeptitClient.Persistency;
using System.Threading.Tasks;

namespace KeptitClient.Handlers
{
    public class GreenTaskHandler
    {
        private GreenkeeperViewModel Mwm { get; set; }

        public GreenTaskHandler(GreenkeeperViewModel mwm)
        {
            this.Mwm = mwm;
        }

        //Gets all Tasks from Database via PersistencyService
        public async Task GetGreenTaskCollection()
        {
            //Brug foreach hvis LoadSubAreaAsync() i PersistencyService kodes som async:
            foreach (var item in await PersistencyService.LoadGreenTaskAsync())
            {
                Mwm.GreenTaskCollection.Add(item);
            }
        }

        // Samlet timer på opgaver, uafhængig af Greenkeeper.
        public async Task GetSumGreenTaskCollection()
        {
            var SumAllTasks =
                from a in await PersistencyService.LoadSumTaskViewAsync()
                orderby a.TaskMinutesTotal descending
                group a by a.GreenTaskTitle
                into AllTasks
                select new
                {
                    D = AllTasks.Key,
                    Timer = AllTasks.Sum(x => x.TaskMinutesTotal) / 60,
                    Minutter = AllTasks.Sum(x => x.TaskMinutesTotal) % 60
                };

            // Viser listen uden {} = og andre unødvændige variabel navne.
            var timerialtopgaver =
                from o1 in SumAllTasks
                select new Models.TimerIaltOpgaver() { GreenTaskTitle = o1.D, Hours = o1.Timer, Minutes = o1.Minutter};


            // Viser listen i xaml opgaver siden. 
            Mwm.ListViewOpgaver.DataContext = timerialtopgaver;
        }

    }
}
