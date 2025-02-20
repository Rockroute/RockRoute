using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RockRoute.ViewModels;

namespace RockRoute.Views
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
