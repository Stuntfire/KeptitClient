using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeptitClient.Persistency;
using KeptitClient.ViewModels;
using KeptitClient.Models;
using KeptitClient.Common;

namespace KeptitClient.Handlers
{
    public class FinishedTaskHandler
    {
        private GreenkeeperViewModel Mwm { get; set; }

        public FinishedTaskHandler(GreenkeeperViewModel mvm)
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
                FinishedTask temp_task = new FinishedTask(Mwm.SelectedArea.AreaID, Mwm.SelectedGreenTask.GreenTaskID, Mwm.SelectedSubArea.SubAreaID, Mwm.SelectedGreenKeeper.GreenkeeperID, Mwm.SelectedDate.Date, Mwm.TaskHour, Mwm.TaskMinutes, Mwm.TaskNotes);
                if (Mwm.TaskHour == 0 && Mwm.TaskMinutes == 0)
                {
                    throw new Exception();
                }
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
                PersistencyService.DeleteFinishedTask(Mwm.GreenkeeperInfoToDelete.FinishedTasksID);
            }
            catch (Exception)
            {

                throw;
            }
        } 
    }
}
