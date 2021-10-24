using System.Globalization;
using System.Threading;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Extensions;
using Presentation.Notifications;
using Presentation.Windows;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            var services = new ServiceCollection();
            services.AddPresentationServices();
            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // var loginWindow = _serviceProvider.GetService<LoginWindow>();
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
            // loginWindow?.Show();
            // AppointmentAlert.Show();
        }
    }
}
