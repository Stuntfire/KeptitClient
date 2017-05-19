using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Windows.UI.Popups;
using KeptitClient.Common;
using KeptitClient.Models;
using Task = System.Threading.Tasks.Task;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace KeptitClient.Persistency
{
    public class PersistencyService
    {
        //const string til serverenx
        const string serverUrl = "http://keptit.azurewebsites.net";

        // Henter alle Greenkeeper fra tabellen Greenkeepers
        public static async Task<ObservableCollection<Greenkeeper>> LoadGreenkeeperAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/greenkeepers";

                HttpResponseMessage response = await client.GetAsync(urlString);
                if (response.IsSuccessStatusCode)
                {
                    var greenkeeperliste = response.Content.ReadAsAsync<ObservableCollection<Greenkeeper>>().Result;
                    return greenkeeperliste;
                }
                return null;
            }
        }

        // Henter alle Area fra tabellen Areas
        // hvis async Task:
        // public static async Task<ObservableCollection<Area>> LoadAreasAsync()
        public static async Task<ObservableCollection<Area>> LoadAreasAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/areas";

                HttpResponseMessage response = await client.GetAsync(urlString);
                if (response.IsSuccessStatusCode)
                {
                    var arealiste = response.Content.ReadAsAsync<ObservableCollection<Area>>().Result;
                    return arealiste;
                }
                return null;
            }
        }

        // Henter alle SubArea fra tabellen SubAreas
        public static async Task<ObservableCollection<SubArea>> LoadSubAreasAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/subareas";

                HttpResponseMessage response = await client.GetAsync(urlString);
                if (response.IsSuccessStatusCode)
                {
                    var subarealiste = response.Content.ReadAsAsync<ObservableCollection<SubArea>>().Result;
                    return subarealiste;
                }
                return null;
            }
        }

        // Henter alle task fra tabellen task
        public static async Task<ObservableCollection<GreenTask>> LoadGreenTaskAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/greentasks";

                HttpResponseMessage response = await client.GetAsync(urlString);
                if (response.IsSuccessStatusCode)
                {
                    var greentaskliste = response.Content.ReadAsAsync<ObservableCollection<GreenTask>>().Result;
                    return greentaskliste;
                }
                return null;
            }
        }

        // Henter alle finishedtask fra tabellen finishedtask
        public static async Task<ObservableCollection<FinishedTask>> LoadFinishedtaskAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/finishedtasks";

                HttpResponseMessage response = await client.GetAsync(urlString);
                if (response.IsSuccessStatusCode)
                {
                    var finishedtaskliste = response.Content.ReadAsAsync<ObservableCollection<FinishedTask>>().Result;
                    return finishedtaskliste;
                }
                return null;
            }
        }
        /// <summary>
        /// Henter alle Greenkeeper Info fra DB-View GreenkeeperInfo
        /// </summary>
        /// <returns></returns>
        public static async Task<ObservableCollection<GreenkeeperInfo>> LoadGreenkeeperInfoAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/greenkeeperInfoes";

                HttpResponseMessage response = await client.GetAsync(urlString);
                if (response.IsSuccessStatusCode)
                {
                    var AltInfoliste = response.Content.ReadAsAsync<ObservableCollection<GreenkeeperInfo>>().Result;
                    return AltInfoliste;
                }
                return null;
            }
        }
        /// <summary>
        /// Summer alle Area-minutter fra DB-View SumAreaView
        /// </summary>
        /// <returns></returns>
        public static async Task<ObservableCollection<SumAreaView>> LoadSumAreaViewAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/SumAreaViews";

                HttpResponseMessage response = await client.GetAsync(urlString);
                if (response.IsSuccessStatusCode)
                {
                    var SumAreaViewMinutter = response.Content.ReadAsAsync<ObservableCollection<SumAreaView>>().Result;
                    return SumAreaViewMinutter;
                }
                return null;
            }
        }
        /// <summary>
        /// Summer alle minutter og samler dato'er fra GreenTask fra DB-View SumAreaView
        /// </summary>
        /// <returns></returns>
        public static async Task<ObservableCollection<SumTaskDateView>> LoadSumTaskDateViewAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/SumTaskDateViews";

                HttpResponseMessage response = await client.GetAsync(urlString);
                if (response.IsSuccessStatusCode)
                {
                    var SumTaskDateViewMinutter = response.Content.ReadAsAsync<ObservableCollection<SumTaskDateView>>().Result;
                    return SumTaskDateViewMinutter;
                }
                return null;
            }
        }

        /// <summary>
        /// Summer alle minutter og samler dem fra GreenTask fra DB-View SumTaskView
        /// </summary>
        /// <returns></returns>
        public static async Task<ObservableCollection<SumTaskView>> LoadSumTaskViewAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/SumTaskViews";

                HttpResponseMessage response = await client.GetAsync(urlString);
                if (response.IsSuccessStatusCode)
                {
                    var SumTaskViewMinutter = response.Content.ReadAsAsync<ObservableCollection<SumTaskView>>().Result;
                    return SumTaskViewMinutter;
                }
                return null;
            }
        }

        // Henter alle Greenkeeper Minutter Pr Dag fra DB-View GreenkeeperMinutterPrDag
        public static async Task<ObservableCollection<GreenkeeperMinutterPrDag>> LoadGreenkeeperMinutterPrDagAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/GreenkeeperMinutterPrDags";

                HttpResponseMessage response = await client.GetAsync(urlString);
                if (response.IsSuccessStatusCode)
                {
                    var AlleMinutterPrDagPrGreenkeeperListe = response.Content.ReadAsAsync<ObservableCollection<GreenkeeperMinutterPrDag>>().Result;
                    return AlleMinutterPrDagPrGreenkeeperListe;
                }
                return null;
            }
        }

        // Post finishedtask
        public static void PostFinishedtask(FinishedTask finishedtask)
        {

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/finishedtasks"));
                try
                { 
                    //todo det her vil ikke nødvendigvis fange en fejlkode fra serveren
                    var response = client.PostAsJsonAsync<FinishedTask>("api/finishedtasks", finishedtask).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        ContentDialog cd = new ContentDialog();
                        cd.Content = "Din opgave er gemt";
                        cd.PrimaryButtonText = "OK";
                        cd.ShowAsync();
                    }
                }

                catch (Exception e)
                {
                    MessageDialog Error = new MessageDialog("Error : " + e);
                    Error.Commands.Add(new UICommand { Label = "Ok" });
                    Error.ShowAsync().AsTask();
                }

            }
        }
    }
}
