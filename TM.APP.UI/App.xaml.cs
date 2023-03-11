using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Autofac;
using Autofac.Core;
using Microsoft.Extensions.DependencyInjection;
using TM.APP.UI.App_Core;
using TM.APP.UI.Interfaces;
using TM.APP.UI.Services;
using TM.APP.UI.ViewModels;
using TM.APP.UI.Views;
using TM.DotNet.Entities;

namespace TM.APP.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        //Delegates = variable that points to a function
        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>(_serviceProvider => new MainWindow
            {
                DataContext = _serviceProvider.GetRequiredService<MainViewModel>()
            });
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<UserViewModel>();
            services.AddSingleton<HomeViewModel>();
//            services.AddSingleton<TmDbContext>();
            services.AddSingleton<INaviService,NaviService>();
            services.AddSingleton<Func<Type,ViewModel>>(_serviceProvider => viewModelType => (ViewModel)_serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
           var MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
           MainWindow.Show();

            base.OnStartup(e);

        }
        

    }
}
