using KeptitClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Handlers
{
    public class TaskHandler
    {
        private MainViewModel Mwm { get; set; }

        public ObservableCollection<Tasks> TasksCollection { get; set; }

        public TaskHandler(MainViewModel mwm)
        {
            this.Mwm = mwm;
        }

        //Gets all Tasks from Database via PersistencyService
        //public async Task GetTasks()
        //{
        //    this.TasksCollection = await PersistencyService.LoadTasksAsync();

        //    //Brug foreach hvis LoadTasksAsync() i PersistencyService kodes som async:
        //    foreach (var item in await PersistencyService.LoadTasksAsync())
        //    {
        //        this.TasksCollection.Add(item);
        //    }
        //}
    }
}
