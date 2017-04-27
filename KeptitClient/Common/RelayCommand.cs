using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace KeptitClient.Common
{
    public class RelayCommand : ICommand
    {
        #region Properties
        private Action methodToExecute = null;
        private Func<bool> methodToDetectCanExecute = null;
        private DispatcherTimer canExecuteChangedEventTimer = null;
        #endregion

        public RelayCommand(Action methodToExecute, Func<bool> methodToDetectCanExecute)
        {
            this.methodToExecute = methodToExecute;
            this.methodToDetectCanExecute = methodToDetectCanExecute;

            this.canExecuteChangedEventTimer = new DispatcherTimer();
            this.canExecuteChangedEventTimer.Tick += canExecuteChangedEventTimer_Tick;
            this.canExecuteChangedEventTimer.Interval = new TimeSpan(0, 0, 1);
            this.canExecuteChangedEventTimer.Start();
        }

        #region Methods
        public void Execute(object parameter)
        {
            this.methodToExecute();
        }

        public bool CanExecute(object parameter)
        {
            if (this.methodToDetectCanExecute == null)
            {
                return true;
            }
            else
            {
                return this.methodToDetectCanExecute();
            }
        }

        public event EventHandler CanExecuteChanged;

        void canExecuteChangedEventTimer_Tick(object sender, object e)
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
        #endregion
    }

    public interface ICommand
    {
    }
}
