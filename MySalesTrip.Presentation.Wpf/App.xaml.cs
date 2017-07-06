using Autofac;
using MySalesApp.Business;
using MySalesApp.Data.Dal;
using MySalesApp.Service;
using MySalesTrip.Presentation.Wpf.ViewModel;
using System.IO;
using System.Reflection;
using System.Windows;

namespace MySalesTrip.Presentation.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IContainer Container { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var dbPath = Path.Combine(dir, "MySalesTripData.db");

            var builder = new ContainerBuilder();
            builder.RegisterModule(new Dalmodule() { DBPath = dbPath });
            builder.RegisterModule<ValidationModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<ViewModelModule>();

            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                var mainWindowViewModel = Container.ResolveOptional<IMainView>();

                MainWindow window = new Wpf.MainWindow()
                {
                    DataContext = mainWindowViewModel
                };

                MainWindow = window;
            }

            MainWindow.Show();
        }
    }
}