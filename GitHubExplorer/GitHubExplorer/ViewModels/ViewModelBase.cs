using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExplorer.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

        private bool _isLoaderRunning;

        public bool IsLoaderRunning
        {
            get { return _isLoaderRunning; }
            set { _isLoaderRunning = value; Notify(); }
        }

    }
}
