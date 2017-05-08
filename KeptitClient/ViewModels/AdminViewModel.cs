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
    class AdminViewModel
    {
        public AdminViewModel()
        {

        }

        #region Methods
        #endregion

        #region Properties
        #endregion

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

        #region INotify
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
