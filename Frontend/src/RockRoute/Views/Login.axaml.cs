using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RockRoute.ViewModels;
using RockRoute.Classes;
using Newtonsoft.Json;
 

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

        private void NeedAccountButton(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            
            //CRating rating = new CRating("21", 6); //Create a new rating of User id 21, rate 6
            
            //string ratingAsString = JsonConvert.SerializeObject(rating); //Converts the rating into JSON String
            //System.Console.WriteLine(ratingAsString); //Prints the JSON string
            
            //CRating ratingJSONagain = JsonConvert.DeserializeObject<CRating>(ratingAsString); //Converts the JSON string into Object rating
            //System.Console.WriteLine(ratingJSONagain.UserID); //prints the converted object UserID (21)
            
            //Below is frontend bits
            //LogBookConvert();
            var NewWindow = new CreateAccount();
           //NewWindow.WindowState = WindowState.Maximized;
            Hello12();
            NewWindow.Show();
            this.Close();

        }
    }
}
