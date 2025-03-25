using Microsoft.Extensions.DependencyInjection;
using OfficeWebshopAdminPanelApp.Services;
using OfficeWebshopAdminPanelApp.ViewModels;
using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Windows;

namespace OfficeWebshopAdminPanelApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            Services = serviceCollection.BuildServiceProvider();

            var mainWindow = Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton(new HttpClient { BaseAddress = new Uri("https://your-laravel-api.com/") });
            services.AddSingleton<AuthService>();
            services.AddTransient<LoginViewModel>();
            services.AddSingleton<MainWindow>();
        }
    }

}
