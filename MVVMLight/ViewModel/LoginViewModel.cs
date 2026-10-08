using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVMLight.IService;
using MVVMLight.Model;
using MVVMLight.Model.DTO;
using MVVMLigtDemo.IService;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVVMLight.ViewModel
{
    public class LoginViewModel:ViewModelBase
    {
        private IService<User, ViewUser> service;
        public LoginViewModel(IService<User,ViewUser> t1)
        {
            service=t1;
        }
       
        private string _account;
        public string Account
        {
            get
            {
                return _account;
            }
            set
            {
                _account = value;
                RaisePropertyChanged();
            }
        }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _ = value;
                RaisePropertyChanged();
            }
        }
        public RelayCommand LoginCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var exp =Expressionable.Create<ViewUser>();
                    exp.And(it=>it.Account==Account);
                    exp.And(it => it.Password ==Password);
                    var list=service.GetList(exp);
                    if (list.Count!=1)
                    {
                        MessageBox.Show("登录失败");
                        return;
                    }
                    Application.Current.MainWindow.Hide();


                    string fullName = "MvvMLight.MainWindow";
                    Type type = Type.GetType(fullName);
                    var main = (Window)Activator.CreateInstance(type);
                    main.ShowDialog();
                });
            }
        }
        public RelayCommand AddEditCommand
        {
            get
            {
                return new RelayCommand(() =>
                {

                });
            }
        }
        public RelayCommand<object>  DeleteCommand
        {
            get
            {
                return new RelayCommand<object>((obj) =>
                {
                    int id = int.Parse(obj.ToString());
                    if (userService.)
                    {

                    }
                });
            }
        }
        public RelayCommand<object> SendCommand
        {
            get
            {
                return new RelayCommand<object>((obj) =>
                {
                    string s = "你好";
                    User u = new User() { Account = obj.ToString()+"yyhyhuugygyu" };
                    Messenger.Default.Send(u);
                   
                });
            }
        }
    }
}
