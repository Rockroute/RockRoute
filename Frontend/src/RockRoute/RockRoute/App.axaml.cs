using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using RockRoute.Views;
using RockRoute.ViewModels;
using Avalonia.Controls;

namespace RockRoute;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainWindow = new Login();
            //mainWindow.WindowState = WindowState.Maximized; //Uncomment this, This is just so i need minimise all the time to see debugger
            desktop.MainWindow = mainWindow;
            //{
                //DataContext = new MainWindowViewModel(),
            //};
        }

        base.OnFrameworkInitializationCompleted();
    }
}