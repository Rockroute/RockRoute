using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using System.Linq;
using System.Collections.Generic;
using RockRoute.ViewModels;
using RockRoute.Classes;
using RockRoute.Helper;

namespace RockRoute.Views {
    public partial class LogBookTab : UserControl
    {
        public LogBookTab()
        {
            InitializeComponent();
        }

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

        // add image for the playlist can be writen here 
        public void AddImageToPlaylist(object? sender, Avalonia.Interactivity.RoutedEventArgs e) {

        }
        
        // will make a playlist ready to be sent to the database 
        public async void MakePlaylist(object? sender, Avalonia.Interactivity.RoutedEventArgs e) {
            // should print each of the string entered into the colabID textboxs
            
            var newPlaylist = await LogBookFunctions.newPlaylist(Program.loggedInUser.UserId, PlaylistNameBox.Text, GetColabIDs(sender,e));
            if (newPlaylist)
            {
                System.Console.WriteLine("Updated");
            } else
            {
                System.Console.WriteLine("Something went wrong");
            }
            


            // needs to make the playlist and sent it to the database
        }
        // get all the collaborator IDs for the colabID textBoxs and puts them into a list of strings
        public List<string> GetColabIDs(object? sender, Avalonia.Interactivity.RoutedEventArgs e) {
            List<string> collaborators = new List<string>();

            var panel = ColabIDsControl.GetVisualDescendants().OfType<Panel>().FirstOrDefault();
            
            if (panel != null) {
                foreach (var textBox in panel.GetVisualDescendants().OfType<TextBox>().ToList()) {
                    collaborators.Add(textBox.Text);
                }
            }

            return collaborators;
        }
    }

}