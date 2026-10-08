using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using templatePack空白项目.Models;
using templatePack空白项目.Views;

namespace templatePack空白项目.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private Users users = new Users() { Name = "admin", Pass = "123456" };
        public Users Users
        {
            get { return users; }

            set { users = value; RaisePropertyChanged(); }
        }
        private IContainerProvider _c;
        public LoginViewModel(IContainerProvider c)
        {
            _c = c;
        }

        public DelegateCommand LoginCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (Users.Name == "admin" && Users.Pass == "123456")
                    {
                        //获取窗口对象
                        Login w1 = _c.Resolve<Login>();
                        w1.DialogResult = true;

                    }
                });
            }
        }
    }
}
