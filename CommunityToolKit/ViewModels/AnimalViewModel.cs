using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolKit.Messagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace CommunityToolKit.ViewModels
{
    //注册消息 接收消息
    //接收字符串
    //WeakReferenceMessenger.Default.Register<string>(this, (r, m) =>
    //{
    //    Msg = m;
    //});

    // 直接接收User消息
    //WeakReferenceMessenger.Default.Register<User>(this, (r, m) =>
    //{
    //    Msg = m.Name;
    //});

    // 对User进行消息的包装 接收LoginInfoMessage类型
    public class AnimalViewModel:ObservableObject
    {
        public AnimalViewModel()
        {
            WeakReferenceMessenger.Default.Register<LoginInfoMessage>(this, (r,m) =>
            {
                Msg = m.Value.Name;
            });
        }
        private string msg;
        public string Msg
        {
            get
            {
                return msg;
            }
            set => SetProperty(ref msg, value);
        }
    }
}
