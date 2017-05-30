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
using Windows.UI.Xaml.Media.Imaging;

namespace KeptitClient.ViewModels
{
    public class MainViewModel
    {
        #region Handlers
        public FinishedTaskHandler FinishedTaskHandler { get; set; }
        public GreenkeeperInfoHandler GreenkeeperInfoHandler { get; set; }
        public AreaHandler AreaHandler { get; set; }
        public GreenTaskHandler GreenTaskHandler { get; set; }
        public GreenkeeperMinutterPrDagHandler GreenkeeperMinutterPrDagHandler { get; set; }
       
        public GreenkeeperHandler GreenkeeperHandler { get; set; }
        #endregion

        #region RelayCommands

        private ICommand _addTaskCommand;
        public ICommand AddTaskCommand
        {
            get { return _addTaskCommand; }
            set { _addTaskCommand = value; }
        }

        private ICommand _addGreenkeeperCommand;

        public ICommand AddGreenkeeperCommand
        {
            get { return _addGreenkeeperCommand; }
            set { _addGreenkeeperCommand = value; }
        }

        private ICommand _deleteGreenkeeperCommand;
        public ICommand DeleteGreenkeeperCommand
        {
            get { return _deleteGreenkeeperCommand; }
            set { _deleteGreenkeeperCommand = value; }
        }

        private ICommand _deleteFinishedTask;
        public ICommand DeleteFinishedTask
        {
            get { return _deleteFinishedTask; }
            set { _deleteFinishedTask = value; }
        }



        #endregion

        #region Properties

        private string _greenname;
        public string Greenname
        {
            get { return _greenname; }
            set { _greenname = value; }
        }

        private int _greennumber;
        public int Greennumber
        {
            get { return _greennumber; }
            set { _greennumber = value; }
        }

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

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; OnPropertyChanged(nameof(Notes)); }
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
            set { _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
            }
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

       

        private Greenkeeper _selectedWorker;
        public Greenkeeper SelectedWorker {
            get { return _selectedWorker; }
            set { _selectedWorker = value; }
        }

        private Greenkeeper _selectedGreenKeeper;
        public Greenkeeper SelectedGreenKeeper
        {
            get { return _selectedGreenKeeper; }
            set
            {
                _selectedGreenKeeper = value;
                OnPropertyChanged(nameof(SelectedGreenKeeper));
                Loadlist();
            }
        }

        private DateTimeOffset selectedDateAdmin;

        public DateTimeOffset SelectedDateAdmin
        {
            get { return selectedDateAdmin; }
            set
            {
                selectedDateAdmin = value;
                OnPropertyChanged(nameof(SelectedDateAdmin));
                LoadAltListe();
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

        private Greenkeeper _deletegreenkeeper;

        public Greenkeeper DeleteGreenkeeper
        {
            get { return _deletegreenkeeper; }
            set { _deletegreenkeeper = value; }
        }

        private GreenkeeperInfo _greenkeeperInfoToDelete;
        public GreenkeeperInfo GreenkeeperInfoToDelete
        {
            get { return _greenkeeperInfoToDelete; }
            set
            {
                _greenkeeperInfoToDelete = value;
                OnPropertyChanged(nameof(GreenkeeperInfoToDelete));

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

        private ObservableCollection<GreenkeeperMinutterPrDag> _greenkeeperInfoCollection2;
        public ObservableCollection<GreenkeeperMinutterPrDag> GreenkeeperInfoCollection2
        {
            get { return _greenkeeperInfoCollection2; }
            set
            {
                _greenkeeperInfoCollection2 = value;
                OnPropertyChanged(nameof(GreenkeeperInfoCollection2));
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

        private ObservableCollection<GreenkeeperInfo> _getGreenkeeperNavnSortedList;
        public ObservableCollection<GreenkeeperInfo> GetGreenkeeperNavnSortedList
        {
            get { return _getGreenkeeperNavnSortedList; }
            set
            {
                _getGreenkeeperNavnSortedList = value;
                OnPropertyChanged(nameof(GetGreenkeeperNavnSortedList));
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

        private ListView listViewAnsat;

        public ListView ListViewAnsat
        {
            get { return listViewAnsat; }
            set
            {
                listViewAnsat = value;
                OnPropertyChanged(nameof(ListViewAnsat));
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

        #region Værdier til Antal timer og -minutter ComboBox's
        /// <summary>
        /// HourList og SetHourIndex() samt MinuteList og SetMinuteList
        /// sætter de værdier der bliver vis i GUI for hhv.
        /// ComboBox Antal timer og ComboBox Antal minutter.
        /// </summary>
        private List<int> _hourList;

        public List<int> HourList {
            get { return _hourList; }
            set { _hourList = value; }
        }

        public void SetHourIndex()
        {
            HourList = new List<int>();

            for (int i = 0; i < 24; i++)
            {
                HourList.Add(i);
            }
        }

        private List<int> _minuteList;

        public List<int> MinuteList {
            get { return _minuteList; }
            set { _minuteList = value; }
        }

        public void SetMinuteIndex()
        {
            MinuteList = new List<int>();
            MinuteList.Add(0);
            MinuteList.Add(15);
            MinuteList.Add(30);
            MinuteList.Add(45);
        }

        #endregion


        public MainViewModel()
        {
            SetHourIndex();
            SetMinuteIndex();
            GreenkeeperInfoCollection = new ObservableCollection<GreenkeeperInfo>();
            GreenkeeperInfoCollection2 = new ObservableCollection<GreenkeeperMinutterPrDag>();

            GreenkeeperMinutterPrDagCollection = new ObservableCollection<GreenkeeperMinutterPrDag>();
            GetGreenkeeperNavnSortedList = new ObservableCollection<GreenkeeperInfo>();
            AlleTimerOgMinutterCollection = new ObservableCollection<GreenkeeperInfo>();
            SelectedGreenKeeper = new Greenkeeper(0, "");
            
            DateTime dt = DateTime.Today;
            SelectedDate = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            SelectedDateAdmin = DateTimeOffset.Now;

            LoadAllCollections();
            AddTaskCommand = new RelayCommand(FinishedTaskHandler.PostFinishedTask, IsEmpty);
            AddGreenkeeperCommand = new RelayCommand(GreenkeeperHandler.PostGreenkeeper, null);
            DeleteFinishedTask = new RelayCommand(FinishedTaskHandler.DeleteFinishedTask, null);
            DeleteGreenkeeperCommand = new RelayCommand(GreenkeeperHandler.DeleteGreenkeeper, null);

            #region AllListviews
            ListViewSamlet = new ListView();
            ListViewSamlet2 = new ListView();
            ListViewOpgaverPrDag = new ListView();
            ListViewOpgaver = new ListView();
            ListViewOmraader = new ListView();
            ListViewAnsat = new ListView();
            #endregion
        }

        #region Methods

        public void Loadlist()
        {
            GreenkeeperInfoHandler = new GreenkeeperInfoHandler(this);
            GreenkeeperInfoHandler.LoadUpdatedList();
        }

        public void LoadAltListe()
        {
            GreenkeeperMinutterPrDagHandler = new GreenkeeperMinutterPrDagHandler(this);
            GreenkeeperMinutterPrDagHandler.LoadUpdatedListAllAdmin();
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

        public bool IsFinishedTaskSelected()
        {
            if (GreenkeeperInfoToDelete.FinishedTasksID != 0)
            {
                return true;
            }
            return false;
        }

        private void LoadAllCollections()
        {


            GreenKeeperCollection = new ObservableCollection<Greenkeeper>();
            GreenkeeperHandler = new GreenkeeperHandler(this);
            GreenkeeperHandler.GetGreenkeeperCollection();
            GreenKeeperCollection.OrderByDescending(x => x.GreenkeeperName);

            AreaCollection = new ObservableCollection<Area>();
            AreaHandler = new AreaHandler(this);
            AreaHandler.GetAreaCollection();
            AreaHandler.VisOmraader();

           
           

            FinishedTaskCollection = new ObservableCollection<FinishedTask>();
            FinishedTaskHandler = new FinishedTaskHandler(this);

            GreenTaskCollection = new ObservableCollection<GreenTask>();
            GreenTaskHandler = new GreenTaskHandler(this);
            GreenTaskHandler.GetGreenTaskCollection();
            GreenTaskHandler.GetSumGreenTaskCollection();

            GreenkeeperInfoHandler = new GreenkeeperInfoHandler(this);
            GreenkeeperInfoHandler.GetGreenTaskInfoCollection();

            GreenkeeperMinutterPrDagHandler = new GreenkeeperMinutterPrDagHandler(this);
            GreenkeeperMinutterPrDagHandler.GetGreenkeeperMinutterPrDagSortedList();
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
