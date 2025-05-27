using CoursWpfOptec.Models.Entities;
using CoursWpfOptec.Models.Repositories;
using CoursWpfOptec.Models.Services;
using CoursWpfOptec.ViewModels;
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
            services.AddSingleton<IList<Voiture>>(sp => 
                new List<Voiture>()
                {
                    new Voiture("1-ABC-123"),
                    new Voiture("1-DEF-456")
                }
            ); //Simulation de la DB

            services.AddSingleton<IVoitureRepository, VoitureService>();
        }
    }

}
