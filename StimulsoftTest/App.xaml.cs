using System.Windows;

namespace StimulsoftTest
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var viewModel = new MainWindowViewModel();
            var view = new MainWindowView
            {
                DataContext = viewModel
            };
            view.Show();
        }
    }
}
