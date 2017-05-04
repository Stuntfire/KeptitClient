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
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;
using KeptitClient.Persistency;

namespace KeptitClient.ViewModels
{
    public class MainViewModel
    {
        #region Handlers
        public FinishedTaskHandler FinishedTaskHandler { get; set; }
        public GreenkeeperInfoHandler GreenkeeperInfoHandler { get; set; }

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
                OnPropertyChanged(nameof(SelectedGreenKeeper));
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
                OnPropertyChanged(nameof(GreenKeeperCollection));
            }
        }

        private ObservableCollection<GreenkeeperInfo> alletimerogminutterCollection;

        public ObservableCollection<GreenkeeperInfo> AlleTimerOgMinutterCollection
        {
            get { return alletimerogminutterCollection; }
            set { alletimerogminutterCollection = value; }
        }


        public int result;
        public float timerud;
        public float minutterud;
        float resultatetaftimer;
        public int resultatetafminutter;
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



        #endregion

        public MainViewModel()
        {
            GreenkeeperInfoCollection = new ObservableCollection<GreenkeeperInfo>();
            AlleTimerOgMinutterCollection = new ObservableCollection<GreenkeeperInfo>();

            SelectedGreenKeeper = new Greenkeeper(0, "");
            FinishedTaskHandler = new FinishedTaskHandler(this);

            DateTime dt = DateTime.Now;
            _selectedDate = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());

            LoadAllCollections();
            AddTaskCommand = new RelayCommand(FinishedTaskHandler.PostFinishedTask, IsEmpty);

            ListViewSamlet = new ListView();
            BeregnAlt();
        }

        #region Methods

        public bool IsEmpty()
        {
            if (SelectedGreenKeeper.GreenkeeperName != "")
            {
                return true;
            }
            return false;
        }

        // Beregner for hver greenkeeper der viser navn,timer og antal minutter.
        public async Task BeregnAlt()
        {

            var NavnOgTimerIalt =
               from t in AlleTimerOgMinutterCollection
               orderby t.GreenkeeperName
               group t by t.GreenkeeperName into Ansat
               select new
               {
                   Greenkeeper = Ansat.Key,
                   TimerIalt = Ansat.Sum(x => x.Hours),
                   MinutterIalt = Ansat.Sum(x => x.Minutes),
               };

            foreach (var item in await PersistencyService.LoadGreenkeeperInfoAsync())
            {
                AlleTimerOgMinutterCollection.Add(item);

                
                
            }

            //--------------------------------------------------
            //foreach (var test in NavnOgTimerIalt)
            //{
            //    if (test.MinutterIalt > 60)
            //    {
            //        float result = 0.0F;
            //        float result2 = 0.0F;
            //        timerud = test.MinutterIalt / 60;
            //        resultatetafminutter = test.TimerIalt;
            //        result = timerud + resultatetafminutter;
            //        result2 = (test.MinutterIalt - (timerud * 60));
            //        timerud = result ;
            //        minutterud = result2;
            //    }
            //    else
            //    {

            //    }
            //}
            //---------------------------------------------

            ListViewSamlet.DataContext = NavnOgTimerIalt;


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
            GreenkeeperInfoHandler.GetGreenTaskInfoCollection();

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
