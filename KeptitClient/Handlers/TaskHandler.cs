using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeptitClient.Persistency;
using KeptitClient.ViewModels;

namespace KeptitClient.Handlers
{
   public class TaskHandler
    {
        private MainViewModel mainViewModel;

        public TaskHandler()
        {
            //skal modtage en kopi af view modellen.
        }

        public TaskHandler(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public void CreateTask()
        {
            //var temp_Task = new Task();
            //PersistencyService.PostAsJsonTask();        
        }
    }
}
