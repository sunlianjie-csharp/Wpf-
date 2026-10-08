using CommunityToolKit.Models.DTO;
using CommunityToolKit.Services;
using CommunityToolKit.Services.implementation;
using CommunityToolKit.ViewModels;
using CommunityToolKit.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows;
using ServiceCollection = Microsoft.Extensions.DependencyInjection.ServiceCollection;

namespace CommunityToolKit
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        //添加构造函数
        public App()
        {
            Services = ConfigureServices();
        }
        // 这个属性访问的时候通过 App.Current
        public new static App Current => (App)Application.Current;

        // 目的是通过应用程序对象访问服务容器对象， 以后从容器对象取出各种服务（数据库访问对象 viewmodel对象等等）
        //IServiceProvider 提供服务的接口对象，主要给viewmodel 提供各种服务， 给viewmodel提供各种对象，通过依赖注入viewmodel中

        //依赖注入 一般DI表示，本身viewmodel需要数据库访问类对象，viewmodel依赖于数据库访问类对象，把对象注册到ServiceProvid里面 需要使用的话 通过ServiceProvid取出
        //把对象控制权交给ServiceProvider他进行管理
        //IOC:控制反转，是一个思想， 依赖注入实现IOC一种方式

        // App.Current.Services 存放各种服务

        //以后可以在各个文件通过  App.Current.Services.GetService() 获取对象
        // App.Current.Services.GetService() //获取具体服务  就是一个对象 
        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();// 创建一个服务集合 注册各种服务

            //给services注册各种服务 添加viewmodel对象， 窗口对象  数据库访问对象
            services.AddTransient<Main>(); //添加一个瞬时对象 窗口对象
            services.AddTransient<AnimalWindow>();


            services.AddSingleton<MainViewModel>();//添加一个单例对象，这个单例对象在整个应用当中只存在一个  viewmodel对象。 数据库访问对象
            services.AddSingleton<AnimalViewModel>();


            //数据库访问服务
            services.AddSingleton<IPeople<User, ViewUser>, UserService>();


            return services.BuildServiceProvider();// 创建一个提供服务对象
        }
    }
}

