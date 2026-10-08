using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMLigtDemo.UserControls
{
    /// <summary>
    /// UCPage.xaml 的交互逻辑
    /// </summary>
    public partial class UCPage : UserControl
    {
        public UCPage()
        {
            InitializeComponent();
            cbbPageSize.SelectedIndex = 0;
        }

        //1.注册依赖属性
        // 属性名称  属性类型 所属控件类型 默认值
        public static readonly DependencyProperty PageProperty =
          DependencyProperty.Register("Page", typeof(int), typeof(UCPage),new PropertyMetadata(0));
        
      //  2. 创建包装器属性（通常用于访问依赖属性）

        public int Page
        {
            get { return (int)GetValue(PageProperty); }
            set { 
                
                SetValue(PageProperty, value);
                RaisePageChangedEvent();
                DisableButton();

                tbPageAndTotalPage.Text=$"{Page}/{TotalPage}";
                txtPage.Text = Page.ToString();


            }
        }

        public static readonly DependencyProperty PageSizeProperty =
        DependencyProperty.Register("PageSize", typeof(int), typeof(UCPage), new PropertyMetadata(10));

        public int PageSize
        {
            get { return (int)GetValue(PageSizeProperty); }
            set { SetValue(PageSizeProperty, value); }
        }


        public static readonly DependencyProperty TotalPageProperty =
     DependencyProperty.Register("TotalPage", typeof(int), typeof(UCPage), new PropertyMetadata(0));

        public int TotalPage
        {
            get { return (int)GetValue(TotalPageProperty); }
            set { SetValue(TotalPageProperty, value); }
        }


        // 1.定义路由事件  路由事件的两种事件策略：冒泡事件，隧道事件（JS中称捕获事件）
        // 规律：在WPF中，不以Preview开头的事件，是冒泡事件，以Preview开头是隧道事件
         public static readonly RoutedEvent PageChangedEvent = EventManager.RegisterRoutedEvent(
    "PageChanged", RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(UCPage));

        // 2.添加事件处理程序支持。本质上是用普通事件把路由事件包装一下.让普通的事件变成路由事件。
        public event RoutedEventHandler PageChanged
        {
            add { AddHandler(PageChangedEvent, value); }  // 支持+=
            remove { RemoveHandler(PageChangedEvent, value); }   // 支持-=
        }

        // 3.封装一个触发路由事件PageChangedEvent的方法   Raise触发，类似于OnXXXX
        private void RaisePageChangedEvent()
        {
            RaiseEvent(new RoutedEventArgs(PageChangedEvent));  // 触发路由事件的核心代码。
        }





        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            Page = 1;
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (Page > 1) Page = Page - 1;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (Page < TotalPage) Page = Page + 1;
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
             Page = TotalPage;
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtPage.Text, out int page))
            {
                if (page >= 1 && page <= TotalPage)
                {
                    Page = page;
                }
                else
                {
                    MessageBox.Show($"请输入[1,{TotalPage}]范围的值！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("请输入数字！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void txtPage_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
           e.Handled = !Regex.IsMatch(e.Text, "^[0-9]*$");
        }

        private void cbbPageSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem cbItem = (ComboBoxItem)comboBox.SelectedItem;
            int pageSize = int.Parse(cbItem.Content.ToString().Trim());
            PageSize = pageSize;
            Page = 1;
        }

        private void DisableButton()
        {
            if (Page == 1 && Page != TotalPage)
            {
                btnFirst.IsEnabled = false;
                btnPrev.IsEnabled = false;
                btnNext.IsEnabled = true;
                btnLast.IsEnabled = true;
            }
            else if (Page == TotalPage && Page != 1)
            {
                btnFirst.IsEnabled = true;
                btnPrev.IsEnabled = true;
                btnNext.IsEnabled = false;
                btnLast.IsEnabled = false;
            }
            else if (Page > 1 && Page < TotalPage)
            {
                btnFirst.IsEnabled = true;
                btnPrev.IsEnabled = true;
                btnNext.IsEnabled = true;
                btnLast.IsEnabled = true;
            }
            else
            {
                btnFirst.IsEnabled = false;
                btnPrev.IsEnabled = false;
                btnNext.IsEnabled = false;
                btnLast.IsEnabled = false;
            }
        }
    }
}
