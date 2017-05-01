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

namespace KeptitClient.Persistency
{
    public class PersistencyService
    {
        //const string til serverenx
        const string serverUrl = "http://keptit.azurewebsites.net";

        //Tilføj en udført opgave.
        //public static void PostAsJsonTask(FinishedTask TaskToPost)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(serverUrl);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        try
        //        {
        //            var response = client.PostAsJsonAsync<FinishedTask>("api/finishedtasks", TaskToPost).Result;

        //            if (response.IsSuccessStatusCode)
        //            {
        //                MessageDialogHelper.Show("Udført opgave blev gemt", TaskToPost.FinishedTasksID.ToString());
        //            }
        //            else
        //            {
        //                MessageDialogHelper.Show("Udført opgave blev ikke gemt", TaskToPost.FinishedTasksID.ToString());
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            MessageDialogHelper.Show("Fejl ", TaskToPost.FinishedTasksID.ToString());
        //        }
        //    }
        //}

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
        ////hvis async Task:
        //public static async Task<ObservableCollection<Area>> LoadAreasAsync()
        public static ObservableCollection<Area> LoadAreasAsync()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/areas";

                ////hvis async Task: 
                //HttpResponseMessage response = await client.GetAsync(urlString);
                HttpResponseMessage response = client.GetAsync(urlString).Result;
                if (response.IsSuccessStatusCode)
                {
                    ////hvis async Task:
                    //var arealiste = await getResponse.Content.ReadAsAsync<ObservableCollection<Area>>();
                    //return arealiste;
                    var arealiste = response.Content.ReadAsAsync<ObservableCollection<Area>>().Result;
                    return arealiste;
                }
                return null;
            }
        }

        // Henter alle SubArea fra tabellen SubAreas
        public static ObservableCollection<SubArea> LoadSubAreasAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/subareas";

                HttpResponseMessage response = client.GetAsync(urlString).Result;
                if (response.IsSuccessStatusCode)
                {
                    var subarealiste = response.Content.ReadAsAsync<ObservableCollection<SubArea>>().Result;
                    return subarealiste;
                }
                return null;
            }
        }


    }
}
