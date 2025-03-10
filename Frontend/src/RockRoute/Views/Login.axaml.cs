using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RockRoute.ViewModels;

namespace RockRoute.Views
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void NeedAccountButton(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            LoginViewModel instanceOfClass = new LoginViewModel();
            instanceOfClass.Hello12();
            var NewWindow = new CreateAccount();
            //NewWindow.WindowState = WindowState.Maximized;
            NewWindow.Show();
            this.Close();

        }
    }
}
