using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism手写.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism手写.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        // 定义指令
        public DelegateCommand LoginCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    //1 判断账号密码是否正确

                    //2  获取login窗口
                    Login l1 = App.Current.Container.Resolve<Login>();
                    l1.DialogResult = true;

                });
            }
        }
    }
}

