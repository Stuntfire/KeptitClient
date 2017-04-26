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
        public FinishedTaskHandler FinishedTaskHandler { get; set; }
         
        // ICommands
        public Common.ICommand AddTaskCommand { get; set; }
        //public Common.ICommand DeleteTaskCommand { get; set; }
        //public Common.ICommand SelectTaskCommand { get; set; }
        //public Common.ICommand EditTaskCommand { get; set; }


        //Properties

        //Hours
        private int _taskHour;
        public int taskHour
        {
            get { return _taskHour; }
            set { _taskHour = value; OnPropertyChanged(nameof(taskHour)); }
        }

        //Minutes
        private int _taskMinutes;
        public int taskMinutes
        {
            get { return _taskMinutes; }
            set { _taskMinutes = value; OnPropertyChanged(nameof(taskMinutes)); }
        }


        //Note
        private int _taskNotes;
        public int taskNotes
        {
            get { return _taskNotes; }
            set { _taskNotes = value; OnPropertyChanged(nameof(taskNotes)); }
        }


        //Area
        private Area _taskArea;
        public Area taskArea
        {
            get { return _taskArea; }
            set { _taskArea = value; OnPropertyChanged(nameof(taskArea)); }
        }

        //SubArea

        private SubArea _SubArea;
        public SubArea SubArea
        {
            get { return _SubArea; }
            set { _SubArea = value; OnPropertyChanged(nameof(SubArea)); }
        }

        private ObservableCollection<Task> _taskCollection;
        public ObservableCollection<Task> taskCollection
        {
            get { return _taskCollection; }
            set { _taskCollection = value; }
        }


        // Constructor
        public MainViewModel()
        {
            FinishedTaskHandler = new FinishedTaskHandler(this);
            taskCollection = new ObservableCollection<Task>();

            AddTaskCommand = new RelayCommand(FinishedTaskHandler.CreateTask, null);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
