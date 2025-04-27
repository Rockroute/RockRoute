using Avalonia.Controls;
using Avalonia.VisualTree;
using RockRoute.ViewModels;

namespace RockRoute.Views;

public partial class HomeTab : UserControl
{
    public HomeTab()
    {
        InitializeComponent();
    }
    // will call the SeeMore from the HomeTabViewModel class that will edit the recommendations by adding more


    public void LogOutButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e) {

        var window = this.GetVisualRoot() as Window;
        var newWindow = new Login();
        Program.loggedInUser.UserId = "NOT_LOGGED_IN";
        Program.loggedInUser.Name = "NOT_LOGGED_IN";
        Program.loggedInUser.Email = "NOT_LOGGED_IN";
        Program.loggedInUser.Password = "NOT_LOGGED_IN";
        newWindow.Show();
        window?.Close();
    }
    // should happen upon add activity button press
    //needs to send the activity to the logbook database 
    public void MakeActivity(object? sender, Avalonia.Interactivity.RoutedEventArgs e) {
        // Activity.Text to get the activity name 
        // Description.Text for the description of the activity
        // CalendarEntry.SelectedDate to get datetime 
        //System.Console.WriteLine(Activity.Text);
        //System.Console.WriteLine(Description.Text);
        //System.Console.WriteLine(CalendarEntry.SelectedDate);

    }
    
}