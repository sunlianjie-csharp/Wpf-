using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Controls;

namespace MVVMLight.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
        private UserControl userControl;
        public UserControl UserControl
        {
            get
            {
                return userControl;
            }
            set
            {
                userControl = value;RaisePropertyChanged();
            }
        }
        public RelayCommand<object> OpenCommand
        {
            get
            {
                return new RelayCommand<object>((obj) =>
                {
                    Type t1 = Type.GetType($"MVVMLight.Views.UserCountrols.{obj}"); 
                    UserControl= (UserControl) Activator.CreateInstance(t1);
                });
            }
        }
    }
}