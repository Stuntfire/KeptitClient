using KeptitClient.Models;
using KeptitClient.ViewModels;
using KeptitClient.Persistency;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeptitClient.Common;
using Windows.UI.Xaml.Controls;

namespace KeptitClient.Handlers
{
    public class GreenkeeperHandler
    {
        private GreenkeeperViewModel Mwm { get; set; }

        //Constructor
        public GreenkeeperHandler(GreenkeeperViewModel mwm)
        {
            this.Mwm = mwm;
        }

        //Gets all Greenkeepers from Database via PersistencyService
        public async Task GetGreenkeeperCollection()
        {
            foreach (var item in await PersistencyService.LoadGreenkeeperAsync())
            {
                Mwm.GreenKeeperCollection.Add(item);
            }
        }

        // Post greenkeeper
        public async void PostGreenkeeper()
        {
            try
            {
                Greenkeeper temp_green = new Greenkeeper(Mwm.Greennumber, Mwm.Greenname);
                if (Mwm.Greenname == "" || Mwm.Greennumber < 9999999 || Mwm.Greennumber > 1000000000)
                {
                    throw new Exception();
                }
                PersistencyService.PostGreenkeeper(temp_green);
                Mwm.GreenkeeperInfoCollection.Clear();
                await Mwm.GreenkeeperInfoHandler.GetGreenTaskInfoCollection();
            }
            catch (Exception)
            {
                MessageDialogHelper.Show("felterne skal udfyldes ordentligt", "Fejl: ");
            }
        }

        // Slet Greenkeeper
        public async void DeleteGreenkeeper()
        {
            try
            {
                if (Mwm.SelectedWorker == null)
                {
                    throw new Exception();
                }
                PersistencyService.DeleteGreenkeeper(Mwm.SelectedWorker.GreenkeeperID);
                Mwm.GreenkeeperInfoCollection.Clear();
                await Mwm.GreenkeeperHandler.GetGreenkeeperCollection();
                
                ContentDialog Gcd = new ContentDialog();
                Gcd.Content = "Greenkeeper er slettet";
                Gcd.PrimaryButtonText = "OK";
                await Gcd.ShowAsync();
            }
            catch (Exception)
            {
                ContentDialog Gcd = new ContentDialog();
                Gcd.Content = "Vælg venligst en greenkeeper";
                Gcd.PrimaryButtonText = "OK";
                await Gcd.ShowAsync();
            }
        }
    }


}
