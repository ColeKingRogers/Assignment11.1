using Assignment11._1.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Assignment11._1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            //collection of services
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<Data.InventoryContext>(options =>
            {
                options.UseSqlite("Data Source=inventory.db");
            });//register db context
            services.AddSingleton<MainWindow>(); // Register MainWindow as a singleton
            services.AddSingleton<Services.ICRUD, Services.CRUD>(); // serviceProvider = services.BuildServiceProvider();
            serviceProvider = services.BuildServiceProvider();

        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }

}
