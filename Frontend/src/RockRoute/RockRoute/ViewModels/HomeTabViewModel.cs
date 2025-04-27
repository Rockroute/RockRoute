using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using RockRoute.climbData;
using RockRoute.Models;
using System.Threading.Tasks;
using ReactiveUI;


namespace RockRoute.ViewModels 
{
   
   public class HomeTabViewModel : ReactiveObject 
   {
        // event handler for handeling upadates to the page when changes are made by the behinded code
        public event  PropertyChangedEventHandler? PropertyChanged;
        // the collection used to store the recommendations used for the Home page
        private ObservableCollection<Climb> _recommendations = new();
        public ObservableCollection<Climb> recommendations
        {
            get => _recommendations;
            set => this.RaiseAndSetIfChanged(ref _recommendations, value);
        }
         

        // initialses the class HomeTabViewModel
        public HomeTabViewModel() 
        {
            LoadRecommendations();
        }

        // home pages recommendations will be loaded with this function 
        public async Task LoadRecommendations() 
        {
            List<Climb> RecomendedClimbs = await ProcessData.CreateRandomClimbs();
            recommendations = new ObservableCollection<Climb>(RecomendedClimbs);

            
        }

        // functionalty to the see more feature - adds more to the recommendations list
        public void SeeMore() {
            //System.Console.WriteLine("See More Test");
        }
   }
}