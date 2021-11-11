using Autofac;
using PresentationLayer;
using System.Windows;

namespace FightClubPlanner
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = ContainerConfig.Configure();

            using var scope = container.BeginLifetimeScope();
            var window = scope.Resolve<LoginWindow>();
            window.Show();
        }
    }
}
