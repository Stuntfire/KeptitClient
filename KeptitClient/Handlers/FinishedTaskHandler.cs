using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeptitClient.Persistency;
using KeptitClient.ViewModels;
using KeptitClient.Models;
using KeptitClient.Common;
using Windows.UI.Xaml.Controls;

namespace KeptitClient.Handlers
{
    public class FinishedTaskHandler
    {
        private MainViewModel Mwm { get; set; }

        public FinishedTaskHandler(MainViewModel mvm)
        {
            this.Mwm = mvm;
        }

        public async Task GetFinishedTaskCollection()
        {
            //Brug foreach hvis LoadSubAreaAsync() i PersistencyService kodes som async:
            foreach (var item in await PersistencyService.LoadFinishedtaskAsync())
            {
                Mwm.FinishedTaskCollection.Add(item);
            }
        }

        public async void PostFinishedTask()
        {
            try
            {
                FinishedTask temp_task = new FinishedTask(Mwm.SelectedArea.AreaID, Mwm.SelectedGreenTask.GreenTaskID, Mwm.SelectedGreenKeeper.GreenkeeperID, Mwm.SelectedDate.Date, Mwm.TaskHour, Mwm.TaskMinutes, Mwm.Notes);
                //if (Mwm.TaskHour == 0 && Mwm.TaskMinutes == 0)
                //{
                //    throw new Exception();
                //}
                PersistencyService.PostFinishedtask(temp_task);
                Mwm.GreenkeeperInfoCollection.Clear();
                await Mwm.GreenkeeperInfoHandler.GetGreenTaskInfoCollection();
            }
            catch (Exception)
            {
                MessageDialogHelper.Show("Alle felterne skal udfyldes", "Fejl: ");
            }

        }

        public async void DeleteFinishedTask()
        {
            try
            {
                if (Mwm.GreenkeeperInfoToDelete == null)
                {
                    throw new Exception();
                }
                PersistencyService.DeleteFinishedTask(Mwm.GreenkeeperInfoToDelete.FinishedTasksID);
                Mwm.GreenkeeperInfoCollection.Clear();
                await Mwm.GreenkeeperInfoHandler.GetGreenTaskInfoCollection();

                ContentDialog cd = new ContentDialog();
                cd.Content = "Din opgave er slettet";
                cd.PrimaryButtonText = "OK";
                await cd.ShowAsync();

            }
            catch (Exception)
            {
                ContentDialog cd = new ContentDialog();
                cd.Content = "Vælg venligst en opgave";
                cd.PrimaryButtonText = "OK";
                await cd.ShowAsync();
                
            }
        } 
    }
}
