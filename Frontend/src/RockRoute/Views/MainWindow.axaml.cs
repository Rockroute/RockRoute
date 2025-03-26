using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;

namespace HomeScreen
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Buttons code, not connected to other screens yet
        private void Profile_OnClick(object? sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Open profile");
        }
        private void Home_OnClick(object? sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Open home");
        }
        private void Add_OnClick(object? sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Open add activity page");
        }
        private void Map_OnClick(object? sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Open map");
        }
        private void Saved_OnClick(object? sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Open saved");
        }
        private void AddPic_OnClick(object? sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Add picture");
        }
        private void QuickAdd_OnClick(object? sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Quick add activity");
        }
    }
}
