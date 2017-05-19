﻿using KeptitClient.Models;
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
                from a in await PersistencyService.LoadSumAreaViewAsync()
                group a by a.AreaTitle
                into omraaederne
                select new
                {
                    D = omraaederne.Key,
                    Timer = omraaederne.Sum(x => x.AreaMinutterIalt) / 60,
                    Minutter = omraaederne.Sum(x => x.AreaMinutterIalt) % 60
                };

            Mwm.ListViewOmraader.DataContext = areasdone;
        }
        
    }
}
