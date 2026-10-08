using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVMLight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLight.ViewModel
{
    public class BlogListViewModel:ViewModelBase
    {
        public BlogListViewModel()
        {

        }
        private string msg;
        public string Msg
        {
            get { return msg; }
            set { msg = value; RaisePropertyChanged(); }
        }
        public RelayCommand RelayCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Register<User>(this, msg =>
                    {
                        Msg = msg.Account;
                    });
                });
            }
        }
        public RelayCommand ClearRelayCommand
        {
            get
            {
                new RelayCommand(() =>
                {
                     Msg = "";
                    Messenger.Default.Register<User>(this,Msg);
                });
            }
        }
    }
}
