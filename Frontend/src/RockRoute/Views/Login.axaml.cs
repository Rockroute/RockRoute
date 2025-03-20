using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RockRoute.ViewModels;
using RockRoute.Classes;
using Newtonsoft.Json;
using RockRoute.Helper;

namespace RockRoute.Views
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            DataContext = new LoginViewModel(); //Connects ViewModel to View
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        private void TestTheCroute(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            
            //LoginViewModel AnotherInstance = new LoginViewModel();
            //AnotherInstance.printTheCroute();
        }

        private void NeedAccountButton(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            
            //CRating rating = new CRating("21", 6); //Create a new rating of User id 21, rate 6
            
            //string ratingAsString = JsonConvert.SerializeObject(rating); //Converts the rating into JSON String
            //System.Console.WriteLine(ratingAsString); //Prints the JSON string
            
            //CRating ratingJSONagain = JsonConvert.DeserializeObject<CRating>(ratingAsString); //Converts the JSON string into Object rating
            //System.Console.WriteLine(ratingJSONagain.UserID); //prints the converted object UserID (21)
            

            LoginViewModel instanceOfClass = new LoginViewModel();
            instanceOfClass.PrintLogBookObject();
            //Below is frontend bits
            //LogBookConvert();
            var NewWindow = new CreateAccount();
           //NewWindow.WindowState = WindowState.Maximized;
            NewWindow.Show();
            this.Close();

        }
    }
}
