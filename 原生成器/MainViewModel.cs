using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace 原生成器
{
    public partial class MainViewModel:ObservableObject
    {

        //1把类改成部分类
        //需要继承
        [ObservableProperty]
        private string? name = "张三";
        //指令名
        [RelayCommand]
        public void First()
        {
            MessageBox.Show("sss");
        } 
        [RelayCommand]
        public void Second( object o)
        {
            MessageBox.Show(o.ToString+ "sss");
        }
    }
}
