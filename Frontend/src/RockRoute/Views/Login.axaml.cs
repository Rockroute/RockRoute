using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RockRoute.ViewModels;
using RockRoute.Classes;
using Newtonsoft.Json;
using RockRoute.Helper;
using RockRoute.enums;
using RockRoute.ApiCall;



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

        //Harveys Magic Print Button
        private async void TestTheCroute(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            await APIprogram.RunAsync();

            //testingHelper.tupleTesting();
            //System.Console.WriteLine(LoginFunctions.LoginAccount("Email@Email.com", "PretendThisIsEncrypted"));
            //testingHelper.testingList();
            //testingHelper.TestHelpName("NEVERMIND PRINT HERE INSTEAD");
            //LoginViewModel ahhh = new LoginViewModel(); //These two lines are none static -> meaning you need to create an instance first
            //ahhh.printTheCroute
            
            //LoginViewModel.printTheCroute(); //This is if it were static on LogivViewModel.cs
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
           //NewWindow.WindowState = WindowState.Maximized; //Uncomment this, This is just so i need minimise all the time to see debugger
            NewWindow.Show();
            this.Close();

        }
    }
}
