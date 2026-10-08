using Prism.Mvvm;
using Prism.Regions;
using System.Reflection.PortableExecutable;
using templatePack空白项目.Views.Regions;

namespace templatePack空白项目.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private IRegionManager _m;
        public MainWindowViewModel(IRegionManager m)
        {
            _m = m;
            _m.RegisterViewWithRegion<Header>("HeaderRegion"); //在HeaderRegion显示Header视图
            _m.RegisterViewWithRegion<Left>("LeftRegion");
        }
    }
}
