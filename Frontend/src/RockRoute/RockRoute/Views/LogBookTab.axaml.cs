using Avalonia.Controls;
using Avalonia.VisualTree;
using System.Linq;
using System.Collections.Generic;
using RockRoute.ViewModels;
using RockRoute.Classes;

namespace RockRoute.Views {
    public partial class LogBookTab : UserControl
    {
        public LogBookTab()
        {
            InitializeComponent();
        }

        // add image for the playlist can be writen here 
        public void AddImageToPlaylist(object? sender, Avalonia.Interactivity.RoutedEventArgs e) {

        }
        // will make a playlist ready to be sent to the database 
        public void MakePlaylist(object? sender, Avalonia.Interactivity.RoutedEventArgs e) {
            // should print each of the string entered into the colabID textboxs
            foreach (string colabID in GetColabIDs(sender,e)) {
                System.Console.WriteLine(colabID);
            }
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