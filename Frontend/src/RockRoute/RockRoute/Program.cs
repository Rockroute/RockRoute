using Avalonia;
using System;
using RockRoute.Models;
using RockRoute.Classes;

namespace RockRoute;

class Program
{
    //Dont remove the DebugMode line, Just change between true and false
    //Hides and shows test / buttons that are being used to debug and jump to certain scenarios
    public static bool DebugMode = true;
    public static string runOn = "http://localhost:5297/";
//"http://rockroute.flarenet.co.uk/";

    public static User loggedInUser = new User //Global Var that holds the user logged in details
    {
        UserId = "NOT_LOGGED_IN",
        Name = "NOT_LOGGED_IN",
        Email = "NOT_LOGGED_IN",
        Password = "NOT_LOGGED_IN"
    };

    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.

    



    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
