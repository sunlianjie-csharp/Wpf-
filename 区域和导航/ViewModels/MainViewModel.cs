using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace 区域和导航.ViewModels
{
    public class MainViewModel:BindableBase
    {
        private IRegionNavigationJournal journal;
        private IRegionManager _regionManager;
        public MainViewModel(IRegionManager regionManager)
        {
            // IRegionManager regionManager 
            _regionManager=regionManager;
        }
        public DelegateCommand<Object> OpenCommand
        {
            get
            {
                return new DelegateCommand<object>((obj =>
                {
                    Button btn =obj as Button;
                    string page = btn.Content.ToString();
                    //_regionManager 区域管理器对象
                    //
                    IRegion region =   _regionManager.Regions["ContentRegion"];
                    // region.RequestNavigate(page);
                    NavigationParameters navPars = new NavigationParameters();
                    navPars.Add("name","张三");
                    navPars.Add("age", "18");
                    _regionManager.RequestNavigate("ContentRegion", page, par =>
                    {
                        //par.Error 错误消息
                        //par.Context 导航上下文对象
                        //  par.Context.NavigationService 导航服务
                        // par.Context.Uri
                       
                        if (par.Result==true)
                        {
                           journal=  par.Context.NavigationService.Journal;
                        }
                    },navPars);
                }));
            }
        }
        public DelegateCommand ForwardCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (journal!=null&&journal.CanGoForward)
                    {
                        journal.Clear();
                        MessageBox.Show("清除成功");
                    }
                    else
                    {
                        MessageBox.Show("已将是第一步了");
                    }
                });
       
            }
        }

    }
}
