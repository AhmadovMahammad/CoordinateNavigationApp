using CoordinateNavigation.MVVM.ViewModels;
using CoordinateNavigation.MVVM.Views;
using CoordinateNavigation.Services.Implementations;
using CoordinateNavigation.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace CoordinateNavigation
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices((hostBuilderContext, serviceCollection) =>
            {
                serviceCollection.AddSingleton<IEventAggregator, EventAggregator>();
                serviceCollection.AddSingleton<ICoordinateService, CoordinateService>();

                serviceCollection.AddSingleton<CoordinateViewModel>();
                serviceCollection.AddSingleton(serviceProvider =>
                {
                    CoordinateViewModel? viewModel = _host?.Services.GetRequiredService<CoordinateViewModel>();
                    return new CoordinateView()
                    {
                        DataContext = viewModel,
                    };
                });
            }).Start();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Window window = _host.Services.GetRequiredService<CoordinateView>();
            window?.Show();

            base.OnStartup(e);
        }
    }
}
