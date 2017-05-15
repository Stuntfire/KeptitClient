using KeptitClient.Common;
using KeptitClient.Handlers;
using KeptitClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation.Metadata;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using KeptitClient.Persistency;

namespace KeptitClient.ViewModels
{
    public class GreenkeeperViewModel
    {
        #region Handlers
        public FinishedTaskHandler FinishedTaskHandler { get; set; }
        public GreenkeeperInfoHandler GreenkeeperInfoHandler { get; set; }
        public AreaHandler AreaHandler { get; set; }

        public GreenkeeperMinutterPrDagHandler GreenkeeperMinutterPrDagHandler { get; set; }

        #endregion

        #region RelayCommands

        private ICommand _addTaskCommand;
        public ICommand AddTaskCommand
        {
            get { return _addTaskCommand; }
            set { _addTaskCommand = value; }
        }

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
            set
            {
                _selectedArea = value;
                OnPropertyChanged(nameof(SelectedArea));
            }
        }

        private SubArea _selectedSubArea;
        public SubArea SelectedSubArea
        {
            get { return _selectedSubArea; }
            set
            {
                _selectedSubArea = value;
                OnPropertyChanged(nameof(SelectedSubArea));
            }
        }

        private Greenkeeper _selectedGreenKeeper;
        public Greenkeeper SelectedGreenKeeper
        {
            get { return _selectedGreenKeeper; }
            set
            {
                _selectedGreenKeeper = value;
                OnPropertyChanged(nameof(SelectedGreenKeeper)); LoadUpdatedList();
            }
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

        private ObservableCollection<GreenkeeperInfo> _greenkeeperInfoCollection;
        public ObservableCollection<GreenkeeperInfo> GreenkeeperInfoCollection
        {
            get { return _greenkeeperInfoCollection; }
            set
            {
                _greenkeeperInfoCollection = value;
                OnPropertyChanged(nameof(GreenkeeperInfoCollection));
            }
        }

        private ObservableCollection<GreenkeeperMinutterPrDag> _genkeeperMinutterPrDagCollection;
        public ObservableCollection<GreenkeeperMinutterPrDag> GreenkeeperMinutterPrDagCollection
        {
            get { return _genkeeperMinutterPrDagCollection; }
            set
            {
                _genkeeperMinutterPrDagCollection = value;
                OnPropertyChanged(nameof(GreenkeeperMinutterPrDagCollection));
            }
        }

        private ObservableCollection<GreenkeeperInfo> alletimerogminutterCollection;

        public ObservableCollection<GreenkeeperInfo> AlleTimerOgMinutterCollection
        {
            get { return alletimerogminutterCollection; }
            set { alletimerogminutterCollection = value; }
        }


       
        private ListView listViewSamlet;

        public ListView ListViewSamlet
        {
            get { return listViewSamlet; }
            set
            {
                listViewSamlet = value;
                OnPropertyChanged(nameof(ListViewSamlet));
            }
        }

        private ListView listViewSamlet2;

        public ListView ListViewSamlet2
        {
            get { return listViewSamlet2; }
            set { listViewSamlet2 = value; }
        }

        private ListView _listViewOpgaver;

        public ListView ListViewOpgaver
        {
            get { return _listViewOpgaver; }
            set
            {
                _listViewOpgaver = value;
                OnPropertyChanged(nameof(ListViewOpgaver));
            }
        }

        private ListView _listViewOmraader;

        public ListView ListViewOmraader
        {
            get { return _listViewOmraader; }
            set
            {
                _listViewOmraader = value;
                OnPropertyChanged(nameof(ListViewOmraader));
            }
        }

        private ListView listViewOpgaverPrDag;

        public ListView ListViewOpgaverPrDag
        {
            get { return listViewOpgaverPrDag; }
            set { listViewOpgaverPrDag = value; }
        }





        #endregion

        public GreenkeeperViewModel()
        {
            GreenkeeperInfoCollection = new ObservableCollection<GreenkeeperInfo>();
            GreenkeeperMinutterPrDagCollection = new ObservableCollection<GreenkeeperMinutterPrDag>();
            AlleTimerOgMinutterCollection = new ObservableCollection<GreenkeeperInfo>();
            SelectedGreenKeeper = new Greenkeeper(0, "");
            FinishedTaskHandler = new FinishedTaskHandler(this);
            AreaHandler = new AreaHandler(this);

            DateTime dt = DateTime.Now;
            _selectedDate = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());

            LoadAllCollections();
            AddTaskCommand = new RelayCommand(FinishedTaskHandler.PostFinishedTask, IsEmpty);

            ListViewSamlet = new ListView();
            ListViewSamlet2 = new ListView();
            ListViewOpgaverPrDag = new ListView();
            ListViewOpgaver = new ListView();
            ListViewOmraader = new ListView();
            GreenkeeperInfoHandler.GetGreenInfoSortedList();
            GreenkeeperMinutterPrDagHandler.GetGreenkeeperMinutterPrDagSortedList();
            FinishedTaskHandler.VisDoneTasks();
            AreaHandler.VisOmraader();
        }

        #region Methods

        public async Task LoadUpdatedList()
        {
            var updateList = from t in GreenkeeperInfoCollection
                             where t.GreenkeeperName.Contains(SelectedGreenKeeper.GreenkeeperName)
                             orderby t.Date descending
                             select t;

            foreach (var item in await PersistencyService.LoadGreenkeeperInfoAsync())
            {
                GreenkeeperInfoCollection.Add(item);
            }

            ListViewSamlet2.DataContext = updateList;
            GreenkeeperInfoCollection.Clear();
        }



        public bool IsEmpty()
        {
            try
            {
                if (SelectedGreenKeeper.GreenkeeperName != "")
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageDialogHelper.Show("Greenkeeper er ikke valgt \n Opgaven kunne ikke gemmes!", e.Message);
                return false;
            }

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

            GreenkeeperInfoHandler = new GreenkeeperInfoHandler(this);
            //GreenkeeperInfoHandler.GetGreenTaskInfoCollection();

            GreenkeeperMinutterPrDagHandler = new GreenkeeperMinutterPrDagHandler(this);

        }
        #endregion

    




        #region INotify
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

}
