using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeptitClient.Persistency;
using KeptitClient.ViewModels;
using KeptitClient.Models;

namespace KeptitClient.Handlers
{
   public class FinishedTaskHandler
    {
        private MainViewModel Mwm { get; set; }

        public FinishedTaskHandler(MainViewModel mvm)
        {
            //skal modtage en kopi af view modellen.
            this.Mwm = mvm;
        }

        public void CreateTask()
        {
            var temp_FinishedTask = new FinishedTask();
            //PersistencyService.PostAsJsonFinishedTask();        
        }
    }
}
