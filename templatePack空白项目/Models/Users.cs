using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace templatePack空白项目.Models
{
    public class Users : BindableBase
    {
        private string name;
        public string Name
        { get { return name; } set { name = value; RaisePropertyChanged(); } }


        private string pass;
        public string Pass
        { get { return pass; } set { pass = value; RaisePropertyChanged(); } }
    }
}