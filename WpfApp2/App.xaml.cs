using System.Windows;

namespace WpfApp2
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                Dispatcher.UnhandledException += (sender, ex) =>
                {
                    MessageBox.Show(ex.Exception.Message, "Critical Error",
                                   MessageBoxButton.OK, MessageBoxImage.Error);
                    ex.Handled = true;
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fatal error: {ex.Message}", "App Crash",
                              MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown();
            }
        }
    }
}