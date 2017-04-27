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

namespace KeptitClient.Persistency
{
    public class PersistencyService
    {
        //const string til serverenx
        const string serverURL = "http://keptitwebservice.azurewebsites.net";

        

        //Tilføj en udført opgave.
        public static void PostAsJsonTask(FinishedTask TaskToPost)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.PostAsJsonAsync<FinishedTask>("api/finishedtasks", TaskToPost).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        MessageDialogHelper.Show("Udført opgave blev gemt", TaskToPost.FinishedTasksID.ToString());
                    }
                    else
                    {
                        MessageDialogHelper.Show("Udført opgave blev ikke gemt", TaskToPost.FinishedTasksID.ToString());
                    }
                }
                catch (Exception e)
                {
                    MessageDialogHelper.Show("Fejl ", TaskToPost.FinishedTasksID.ToString());
                }

            }
        }

        public static ObservableCollection<Area> GetArea()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverURL);
                var response = client.GetAsync("api/areas").Result;

                if (response.IsSuccessStatusCode)
                {
                    var areaListe = response.Content.ReadAsAsync<ObservableCollection<Area>>().Result;
                    return areaListe;
                }

                return null;
            }
        }


    }
}
