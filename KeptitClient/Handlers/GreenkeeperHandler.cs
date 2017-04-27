﻿using KeptitClient.Models;
using KeptitClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeptitClient.Handlers
{
    public class GreenkeeperHandler
    {
        private MainViewModel Mwm { get; set; }

        public ObservableCollection<GreenKeeper> GreenkeepersCollection { get; set; }

        //Constructor
        public GreenkeeperHandler(MainViewModel mwm)
        {
            this.Mwm = mwm;
        }

        ////Gets all Greenkeepers from Database via PersistencyService
        //public async Task GetGreenkeepers()
        //{
        //    this.GreenkeepersCollection = await Persistency.PersistencyService.GetAsJsonTask();

        //    //Brug foreach hvis GetAsJsonTask() i PersistencyService kodes som async:
        //    //public static async Task<ObservableCollection<Area>> GetAsJsonTask()
        //    foreach (var item in await Persistency.PersistencyService.GetAsJsonTask())
        //    {
        //        this.AreasCollection.Add(item);
        //    }
        //}

        ////Create et nyt Area
        //public void CreateArea()
        //{
        //    Area temp_Area = new Area(Mwm.SelectedArea.AreaID, Mwm.SelectedArea.AreaTitle);
        //    Persistency.PersistencyService.PostAsJsonTask(temp_Area);
        //}
    }
}
