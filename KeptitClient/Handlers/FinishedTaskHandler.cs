﻿using System;
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

        public async Task GetFinishedTaskCollection()
        {
            //Brug foreach hvis LoadSubAreaAsync() i PersistencyService kodes som async:
            foreach (var item in await PersistencyService.LoadGreenkeeperAsync())
            {
                Mwm.FinishedTaskCollection.Add(item);
            }
        }
    }
}
