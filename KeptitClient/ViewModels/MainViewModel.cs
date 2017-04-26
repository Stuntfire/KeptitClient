using KeptitClient.Common;
using KeptitClient.Handlers;
using KeptitClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KeptitClient.ViewModels
{
    public class MainViewModel 
    {

        //Handlers 
        public TaskHandler TaskHandler { get; set; }
         
        // ICommands
        public Common.ICommand AddTaskCommand { get; set; }
        //public Common.ICommand DeleteTaskCommand { get; set; }
        //public Common.ICommand SelectTaskCommand { get; set; }
        //public Common.ICommand EditTaskCommand { get; set; }


        //Properties

            //Hours
            //Minutes
            //Note
            //Area
            //SubArea
            


        // Constructor
        public MainViewModel()
        {
            TaskHandler = new TaskHandler(this);
            AddTaskCommand = new RelayCommand(TaskHandler.CreateTask, null);
  
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
