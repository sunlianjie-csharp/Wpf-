using Prism.DryIoc;
using Prism.Ioc;
using Prism手写.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Prism手写
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        // 之前设置启动页时候通过 StartupUri="MainWindow.xaml"
        //但是prism建议使用createShell（）设置启动窗体

        //这个方法创建启动窗体的对象，返回是一个Window对象，不会显示，只有初始化完之后才会显示
        //只有调用下面的方法才会显示。
        protected override Window CreateShell()
        {
            //1 使用Main直接创建对象， 不建议使用，导致耦合
            //Main m1 = new Main();

            //2 Container容器，IOC容器
            // 可以从Container容器进行去取  Container.Resolve();
            //Container.Resolve<Main>(); 去取Main这个窗体对象
            return Container.Resolve<Main>();
        }

        // 初始化窗体的方法 InitializeShell这个是在CreateShell之后执行
        protected override void InitializeShell(Window shell)
        {

            //base.InitializeShell(shell);
            Login login = Container.Resolve<Login>();  // 取出login窗体
            if (login == null || login.ShowDialog() != true)  //  如果没登录成功关闭应用程序
            {
                Application.Current.Shutdown();
            }

        }

        // 注册各种服务的方法
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            //1 注册视图 例如窗口 、usercontr   可以手动注册也可以让prism自动去注册
            containerRegistry.Register<Login>();  //  注册一个单例对象窗体


            //2 注册viewmodel 可以手动注册也可以让prism自动去注册不写就帮咱自动注册
            // containerRegistry.Register<LoginViewModel>();


            //3 注册数据库服务 必须手动注册
            //containerRegistry.RegisterSingleton<IDbService，DbService>();


            //4 注册导航区域 手动注册
            //containerRegistry.RegisterForNavigation<Login>();

        }

        // 以下自己封装一个全局的对象 ，使用全局的对象访问服务
        //App.Current.AppContainer 就是 本页面Container
        // App.Current.AppContainer.Resolve<>() 获取各种服务对象
        public new static App Current => (App)Application.Current;
        private IContainerProvider AppContainer
        {
            get
            {
                return Container;
            }
        }

    }
}
