using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism手写.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Prism手写.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private string _title = "ss";
        public string Title
        {
            get { return _title; }

            //set { 

            //    _title = value;
            //    RaisePropertyChanged();
            //} 
            set => SetProperty(ref _title, value);
        }

        public DelegateCommand OpenCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Window w = App.Current.Container.Resolve<Window1>();
                    w.Show();
                });
            }
        }
    }
}
