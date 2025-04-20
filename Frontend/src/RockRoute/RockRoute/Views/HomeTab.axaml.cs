using Avalonia.Controls;
using RockRoute.ViewModels;

namespace RockRoute.Views;

public partial class HomeTab : UserControl
{
    public HomeTab()
    {
        InitializeComponent();
    }
    // will call the SeeMore from the HomeTabViewModel class that will edit the recommendations by adding more
    public void SeeMoreButton(object? sender, Avalonia.Interactivity.RoutedEventArgs e) {
        var homeTabViewModel = (HomeTabViewModel)this.DataContext;
        homeTabViewModel.SeeMore();
    }
}