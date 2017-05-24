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

        public async void PostGreenkeeper()
        {
            try
            {
                Greenkeeper temp_green = new Greenkeeper(Mwm.Greennumber, Mwm.Greenname);
                if (Mwm.Greenname == "" && Mwm.Greennumber < 9999999)
                {
                    throw new Exception();
                }
                PersistencyService.PostGreenkeeper(temp_green);
                Mwm.GreenkeeperInfoCollection.Clear();
                await Mwm.GreenkeeperInfoHandler.GetGreenTaskInfoCollection();
            }
            catch (Exception)
            {
                MessageDialogHelper.Show("Alle felterne skal udfyldes", "Fejl: ");
            }
        }

        public async void DeleteGreenkeeper()
        {
            try
            {
                PersistencyService.DeleteGreenkeeper(Mwm.DeleteGreenkeeper.GreenkeeperID);

                ContentDialog cd = new ContentDialog();
                cd.Content = "Du har nu fjernet en greenkeeper";
                cd.PrimaryButtonText = "OK";
                cd.ShowAsync();

            }
            catch (Exception)
            {
                ContentDialog cd = new ContentDialog();
                cd.Content = "Vælg venligst en greenkeeper";
                cd.PrimaryButtonText = "OK";
                cd.ShowAsync();
            }
        }
    }


}
