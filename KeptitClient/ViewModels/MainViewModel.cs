﻿using KeptitClient.Common;
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
        //public GreenkeeperHandler GreenkeeperHandler { get; set; }

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

        private string _taskNotes;
        public string TaskNotes
        {
            get { return _taskNotes; }
            set { _taskNotes = value; OnPropertyChanged(nameof(TaskNotes)); }
        }

        private ObservableCollection<Greenkeeper> _greenKeeperCollection;
        public ObservableCollection<Greenkeeper> GreenKeeperCollection
        {
            get { return _greenKeeperCollection; }
            set { _greenKeeperCollection = value; }
        }

        private ObservableCollection<Area> _areaCollection;
        public ObservableCollection<Area> AreaCollection
        {
            get { return _areaCollection; }
            set { _areaCollection = value; }
        }

        private ObservableCollection<SubArea> _subAreaCollection;
        public ObservableCollection<SubArea> SubAreaCollection
        {
            get { return _subAreaCollection; }
            set { _subAreaCollection = value; }
        }

        private ObservableCollection<GreenTask> _greenTaskCollektion;

        public ObservableCollection<GreenTask> GreenTaskCollection
        {
            get { return _greenTaskCollektion; }
            set { _greenTaskCollektion = value; }
        }


        private ObservableCollection<FinishedTask> _finishedTaskCollection;
        public ObservableCollection<FinishedTask> FinishedTaskCollection
        {
            get { return _finishedTaskCollection; }
            set { _finishedTaskCollection = value; }
        }

        private DateTimeOffset _selectedDate;

        public DateTimeOffset SelectedDate
        {
            get { return _selectedDate; }
            set { _selectedDate = value; }
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

        private Greenkeeper _selectedGreenKeeper;
        public Greenkeeper SelectedGreenKeeper
        {
            get { return _selectedGreenKeeper; }
            set { _selectedGreenKeeper = value; }
        }

        private GreenTask _selectedGreenTask;

        public GreenTask SelectedGreenTask
        {
            get { return _selectedGreenTask; }
            set
            {
                _selectedGreenTask = value;
                OnPropertyChanged(nameof(SelectedGreenTask));

            }
        }


        #endregion

        public MainViewModel()
        {
            LoadAllCollections();
            //ny relaycommand der binder til finishstaskshandleren
        }

        private void LoadAllCollections()
        {
            GreenKeeperCollection = new ObservableCollection<Greenkeeper>();
            var gkh = new GreenkeeperHandler(this).GetGreenkeeperCollection();

            AreaCollection = new ObservableCollection<Area>();
            var ah = new AreaHandler(this).GetAreaCollection();

            SubAreaCollection = new ObservableCollection<SubArea>();
            var sah = new SubAreaHandler(this).GetSubAreaCollection();

            FinishedTaskCollection = new ObservableCollection<FinishedTask>();
            var fth = new FinishedTaskHandler(this);

            GreenTaskCollection = new ObservableCollection<GreenTask>();
            var gth = new GreenTaskHandler(this).GetGreenTaskCollection();
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
