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
        #region
        public FinishedTaskHandler FinishedTaskHandler { get; set; }
        #endregion

        //ICommands
        #region
        public Common.ICommand AddTaskCommand { get; set; }
        //public Common.ICommand DeleteTaskCommand { get; set; }
        //public Common.ICommand SelectTaskCommand { get; set; }
        //public Common.ICommand EditTaskCommand { get; set; }
        #endregion

        //Properties
        #region
        //Hours
        private int _taskHour;
        public int TaskHour
        {
            get { return _taskHour; }
            set { _taskHour = value; OnPropertyChanged(nameof(TaskHour)); }
        }

        //Minutes
        private int _taskMinutes;
        public int TaskMinutes
        {
            get { return _taskMinutes; }
            set { _taskMinutes = value; OnPropertyChanged(nameof(TaskMinutes)); }
        }


        //Note
        private int _taskNotes;
        public int TaskNotes
        {
            get { return _taskNotes; }
            set { _taskNotes = value; OnPropertyChanged(nameof(taskNotes)); }
        }


        //Area
        private Area _taskArea;
        public Area TaskArea
        {
            get { return _taskArea; }
            set { _taskArea = value; OnPropertyChanged(nameof(TaskArea)); }
        }

        //SubArea

        private SubArea _subArea;
        public SubArea SubArea
        {
            get { return _subArea; }
            set { _subArea = value; OnPropertyChanged(nameof(SubArea)); }
        }

        private ObservableCollection<Task> _taskCollection;
        public ObservableCollection<Task> TaskCollection
        {
            get { return _taskCollection; }
            set { _taskCollection = value; }
        }
        #endregion

        //Constructor og OnPropertyChanged
        #region
        public MainViewModel()
        {
            FinishedTaskHandler = new FinishedTaskHandler(this);
            TaskCollection = new ObservableCollection<Task>();

            AddTaskCommand = new RelayCommand(FinishedTaskHandler.CreateTask, null);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

}
