using CoursWpfOptec.ViewModels.Messages;
using CoursWpfOptec.ViewModels.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.ServiceProcess;
using System.Windows;
using Tools.Mvvm.Messenger;

namespace CoursWpfOptec
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; }

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPopupRepository, Displayer>();
        }
    }

}
