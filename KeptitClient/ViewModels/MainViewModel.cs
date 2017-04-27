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
        #region Handlers
        public FinishedTaskHandler FinishedTaskHandler { get; set; }

        #endregion

        #region RelayCommands
        public Common.ICommand AddTaskCommand { get; set; }
        //public Common.ICommand DeleteTaskCommand { get; set; }
        //public Common.ICommand SelectTaskCommand { get; set; }
        //public Common.ICommand EditTaskCommand { get; set; }
        #endregion

        #region Properties

        private int _taskHour;
        public int TaskHour
        {
            get { return _taskHour; }
            set { _taskHour = value; OnPropertyChanged(nameof(TaskHour)); }
        }

        private int _taskMinutes;
        public int TaskMinutes
        {
            get { return _taskMinutes; }
            set { _taskMinutes = value; OnPropertyChanged(nameof(TaskMinutes)); }
        }

        private int _taskNotes;
        public int TaskNotes
        {
            get { return _taskNotes; }
            set { _taskNotes = value; OnPropertyChanged(nameof(TaskNotes)); }
        }

        private ObservableCollection<Area> _areacollection;
        public ObservableCollection<Area> AreaCollection
        {
            get { return _areacollection; }
            set { _areacollection = value; }
        }

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

        private ObservableCollection<GreenKeeper> _greenKeeperCollection;
        public ObservableCollection<GreenKeeper> GreenKeeperCollection
        {
            get { return _greenKeeperCollection; }
            set { _greenKeeperCollection = value; }
        }

        private Area _selectedArea;
        public Area SelectedArea
        {
            get { return _selectedArea; }
            set { _selectedArea = value; }
        }

        private SubArea _selectedSubArea;
        public SubArea SelectedSubArea
        {
            get { return _selectedSubArea; }
            set { _selectedSubArea = value; }
        }

        private GreenKeeper _selectedGreenKeeper;
        public GreenKeeper SelectedGreenKeeper
        {
            get { return _selectedGreenKeeper; }
            set { _selectedGreenKeeper = value; }
        }

        #endregion

        public MainViewModel()
        {
            AreaCollection = PersistencyService.LoadAreasAsync();
            //SubAreaCollection = PersistencyService.LoadSubAreasAsync();
            //FinishedTaskHandler = new FinishedTaskHandler(this);
            //TaskCollection = new ObservableCollection<FinishedTask>();
            //AddTaskCommand = new RelayCommand(FinishedTaskHandler.CreateTask, null);
        }

        #region INotify
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

}
