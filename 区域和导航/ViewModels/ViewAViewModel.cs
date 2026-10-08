using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace 区域和导航.ViewModels
{
    public class ViewAViewModel : BindableBase, INavigationAware
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }
        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
                RaisePropertyChanged();
            }
        }
        //INavigationAware 目的要接受Main转递过来的参数，要实现INavigationAware
        //第一次进入的时候不会触发，第二次进入的时候触发这个声命周期函数
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            Console.WriteLine("IsNavigationTarget");
            return true;
        }
        //离开页面时执行
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Console.WriteLine("OnNavigatedFrom");
        }
        //进入view
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Console.WriteLine("OnNavigatedTo");
          string n=  navigationContext.Parameters.GetValue<string>("name");
            int a = navigationContext.Parameters.GetValue<int>("age");
            Name = n;
            Age = a;
        }
    }
}
