using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeptitClient.ViewModels;
using KeptitClient.Persistency;

namespace KeptitClient.Handlers
{
    public class AnsatteHandler
    {
        private GreenkeeperViewModel Mwm { get; set; }

        public AnsatteHandler(GreenkeeperViewModel mwm)
        {
            this.Mwm = mwm;
        }
        //Gets all Tasks from Database via PersistencyService
        public async Task GetGreenTaskInfoCollection()
        {
            //Brug foreach hvis LoadSubAreaAsync() i PersistencyService kodes som async:
            foreach (var item in await PersistencyService.LoadGreenkeeperInfoAsync())
            {
                Mwm.GreenkeeperInfoCollection.Add(item);
            }
        }

        // Beregner for hver greenkeeper der viser navn,timer og antal minutter. Flest timer øverst.
        public async Task GetGreenkeeperNavnSortedList()
        {


            var AnsatteNavn =
                from t2 in await PersistencyService.LoadGreenkeeperInfoAsync()
                orderby t2.GreenkeeperName descending
                group t2 by t2.GreenkeeperName
                  into greenkeeper
                select new
                {
                    Navn = greenkeeper.Key,
                    Telefon = greenkeeper.Min(x => x.GreenkeeperID)
                };
            Mwm.ListViewAnsat.DataContext = AnsatteNavn;
           

        }
    }
}

