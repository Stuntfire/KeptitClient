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
using KeptitClient.Persistency;

namespace KeptitClient.ViewModels
{
    public class MainViewModel
    {
        //Handlers 
        #region 
        public FinishedTaskHandler FinishedTaskHandler { get; set; }
        #endregion

        // ICommands
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
            set { _taskNotes = value; OnPropertyChanged(nameof(TaskNotes)); }
        }


        //Area
        private ObservableCollection<Area> _areacollection;

        public ObservableCollection<Area> AreaCollection
        {
            get { return _areacollection; }
            set { _areacollection = value; }
        }



        //SubArea

        private ObservableCollection<SubArea> _subareacollection;

        public ObservableCollection<SubArea> SubAreaCollection
        {
            get { return _subareacollection; }
            set { _subareacollection = value; }
        }

        private ObservableCollection<FinishedTask> _taskCollection;
        public ObservableCollection<FinishedTask> TaskCollection
        {
            get { return _taskCollection; }
            set { _taskCollection = value; }
        }

        private Area selectedArea;
        public Area SelectedArea
        {
            get { return selectedArea; }
            set { selectedArea = value; }
        }

        private SubArea selectedSubArea;
        public SubArea SelectedSubArea
        {
            get { return selectedSubArea; }
            set { selectedSubArea = value; }
        }

        private GreenKeeper selectedGreenKeeper;
        public GreenKeeper SelectedGreenKeeper
        {
            get { return selectedGreenKeeper; }
            set { selectedGreenKeeper = value; }
        }


        #endregion

        // Constructor
        #region
        public MainViewModel()
        {
            AreaCollection = PersistencyService.LoadAreasAsync();
            SubAreaCollection = PersistencyService.LoadSubAreasAsync();
            FinishedTaskHandler = new FinishedTaskHandler(this);
            TaskCollection = new ObservableCollection<FinishedTask>();
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
