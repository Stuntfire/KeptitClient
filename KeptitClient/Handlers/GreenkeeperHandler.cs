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
using KeptitClient.Models;

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

            //Brug foreach hvis LoadGreenkeepersAsync() i PersistencyService kodes som async:
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

    }
}
