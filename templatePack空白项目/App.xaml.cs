using Prism.Ioc;
using System.Windows;
using System.Windows.Controls;
using templatePack空白项目.Views;
using templatePack空白项目.Views.Pages;

namespace templatePack空白项目
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            Login l1 = Container.Resolve<Login>();
            if (l1 == null || l1.ShowDialog() != true)
            {
                Application.Current.Shutdown();
            }
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<Login>();
            containerRegistry.RegisterForNavigation<Page1>();
            containerRegistry.RegisterForNavigation<Page2>();
        }
    }
}
