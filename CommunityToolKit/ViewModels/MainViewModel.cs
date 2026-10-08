using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolKit.Messagers;
using CommunityToolKit.Models.DTO;
using CommunityToolKit.Services;
using CommunityToolKit.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CommunityToolKit.ViewModels
{
    public class MainViewModel:ObservableObject
    {
        private IPeople<User, ViewUser> _services;
        private IServiceProvider i2;
        public MainViewModel(IPeople<User, ViewUser>i1,IServiceProvider _s)
        {
            _services = i1;
            int totelCount = 0;
            _services.GetListByPage((v)=>v.Id<4,2,1,ref  totelCount);
            i2 = _s;
        }
        // 数据来源于数据库
        private List<ViewUser> users;
        public List<ViewUser> Users
        {
            get { return users; }
            set => SetProperty(ref users, value);
        } 
        private string name = "天龙王";
        public string Name
        {
            get
            {
                return name;
            }
            set {
                name = value;  OnPropertyChanged();
                //2SetProperty(ref name, value);
               /* 3,尽量不要用name = value;
                SetProperty(ref name, value);*/
            }

        }
        //       IOC：Inversion of Control，控制反转
        //       DI：Dependency Injection，依赖注入
        //       简单区分
        //      IOC（控制反转）：是思想 / 设计原则
        //      把对象的创建、依赖管理控制权，从业务代码反转交给外部容器，不再自己 new () 对象。
        //      DI（依赖注入）：是实现 IOC 的主要方式
        //      容器把依赖对象 “注入” 到目标类的构造函数 / 属性中。
        //      通俗：IOC 是理念，DI 是落地手段，平时说 IoC 容器（DryIoc、Autofac）本质就是 DI 容器
        private string type = "骨灰盒";
        public string Type
        {
            get { return type; }
            set
            {
                SetProperty(ref name, value);
            }
        }
        public RelayCommand FirstCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MessageBox.Show("无参数的绑定指令");
                });

               
            }
        }
        public RelayCommand<object> SecondCommand
        {
            get
            {
                return new RelayCommand<object>((obj) =>
                {
                    MessageBox.Show("带参数的绑定指令"+obj.ToString());
                });
                


            }
        }
        public RelayCommand<object> ThridCommand
        {
            get
            {
                return new RelayCommand<object>(async (obj) =>
                {
                    await Task.Delay(1000);
                    MessageBox.Show("带参数参数的异步绑定指令" + obj.ToString());
                });



            }
        }
        public RelayCommand OpemCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    AnimalWindow a1=i2.GetService<AnimalWindow>();
                    a1.ShowDialog();
                });
            }
        }
        //    、弱引用在消息传递中的作用
        //1.自动内存管理（最大优势）
        //// 接收方注册消息（WeakReferenceMessenger自动用弱引用保存this）
        //   无需手动 Unregister：当接收者（如 ViewModel）的窗口关闭，且没有其他强引用时，GC 会正常回收它
        //Messenger 内部自动清理：下次发送消息时，会检测接收者是否存活，自动移除无效订阅
        //避免内存泄漏：这是最关键的一点！如果用强引用，忘记 Unregister 会导致 ViewModel 永远无法被回收

        // 采用若引用的方式进行发消息
        // WeakReferenceMessenger.Default.Send("123");


        // 发送自定义对象
        //User u1 = new User() { Name = "ss" };
        //WeakReferenceMessenger.Default.Send(u1);



        //      为什么不建议直接 Send(person)（直接发送业务实体）虽然能跑，但有明显缺陷：消息会串扰
        //消息类型就是业务模型 Person。项目任何别的地方只要 Send(某个Person)，所有订阅了 Register<Person> 的 ViewModel 全部都会收到消息。
        //别的模块传 Person，你这里莫名其妙被触发。
        //语义不清楚
        //看到 Send(p)，别人读代码不知道：这个 Person 是登录消息？删除消息？更新消息？
        //new LoginInfoMessage(p) 一眼就能看懂：这是一条登录信息消息。
        public RelayCommand SendCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    AnimalWindow a1=i2.GetService<AnimalWindow>();
                    a1.Show();
                    User u1=new User() { Name="龙皇异次元"};
                    WeakReferenceMessenger.Default.Send(new LoginInfoMessage(u1));
                });
            }
        }
    }
}
