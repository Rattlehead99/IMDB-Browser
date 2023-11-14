using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using IMDB_Browser.Models;
using IMDB_Browser.ViewModels.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IMDB_Browser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _provider;
        public App()
        {
            //Dependency Injection
            //_host = Host
            //    .CreateDefaultBuilder()
            //    .ConfigureAppConfiguration(x => x.AddJsonFile())
            //    .ConfigureServices((context, services) =>
            //        {
            //            ConfigureServices(context.Configuration, services);
            //        })
            //    .Build();
        }

        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            // ...
            var connectionString = configuration.GetConnectionString("DbConnectionString");
            services.AddSingleton<MainWindow>()
                .AddDbContext<ImdbDbContext>(x => x.UseSqlServer(connectionString,
                    options => options.EnableRetryOnFailure()))
                .AddEntityFrameworkSqlServer()
                .AddSingleton(configuration);
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            //Dependency Injection
            //await _host.StartAsync();

            //No Dependency Injection
            //_provider.GetRequiredService<ImdbDbContext>();
        }

        //private async void Application_Exit(object sender, ExitEventArgs e)
        //{
        //    using (_host)
        //    {
        //        await _host.StopAsync(TimeSpan.FromSeconds(5));
        //    }
        //}

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            //No Dependency Injection
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            configurationBuilder.AddJsonFile("appsettings.json", false);

            ConfigureServices(configurationBuilder.Build(), serviceCollection);

            _provider = serviceCollection.BuildServiceProvider();

            var context = _provider.GetRequiredService<ImdbDbContext>();
            context.Database.Migrate();

            ImportService importService = new ImportService(context);

            importService.InsertRecords();

            MainWindow window = new MainWindow();
            window.Show();


        }
    }
}
