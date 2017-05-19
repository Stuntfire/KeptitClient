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

        public async Task GetSumGreenTaskCollection()
        {
            var SumAllTasks =
                from a in await PersistencyService.LoadSumTaskViewAsync()
                group a by a.GreenTaskTitle
                into AllTasks
                select new
                {
                    Task = AllTasks.Key,
                    Timer = AllTasks.Sum(x => x.TaskMinutesTotal) / 60,
                    Minutter = AllTasks.Sum(x => x.TaskMinutesTotal) % 60
                };
            SumAllTasks.OrderBy(x => x.Timer);
            //Todo Hvad går der galt her? Forkert liste?
           Mwm.ListViewOpgaver.DataContext = SumAllTasks;
        }

    }
}
