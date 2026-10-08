using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace 区域和导航.ViewModels
{
    public class ViewBViewModel : BindableBase, IConfirmNavigationRequest
    {
        //导航确认 导航拦截 导航守卫 离开当前页面时候执行
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            if (navigationContext.Uri.ToString()=="ViewA")
            {
                MessageBoxResult dr = MessageBox.Show("是否允许进入ViewA页面","询问",MessageBoxButton.YesNo);
                continuationCallback((dr == MessageBoxResult.Yes));
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }
    }
}
