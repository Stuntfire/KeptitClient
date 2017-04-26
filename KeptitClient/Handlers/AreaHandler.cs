using KeptitClient.Models;
using KeptitClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Handlers
{
    class AreaHandler
    {
        private MainViewModel Mwm { get; set; }

        public AreaHandler(MainViewModel mvm)
        {
            //skal modtage en kopi af view modellen.
            this.Mwm = mvm;
        }

        public void CreateArea()
        {
            Area temp_Area = new Area(Mwm.TaskArea, Mwm.);
            //PersistencyService.PostAsJsonArea();        
        }
    }
}
