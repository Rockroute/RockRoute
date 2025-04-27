using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using RockRoute.climbData;
using RockRoute.Models;
using System.Threading.Tasks;


namespace RockRoute.ViewModels 
{
    // 
    public class Recommendation 
    {
        public string routeName {get; set;}
        public string routeDescription {get; set;}

        public Recommendation(string name, string description) 
        {
            routeName = name;
            routeDescription = description;
        }
    }
   
   public class HomeTabViewModel : INotifyPropertyChanged 
   {
        // event handler for handeling upadates to the page when changes are made by the behinded code
        public event  PropertyChangedEventHandler? PropertyChanged;
        // the collection used to store the recommendations used for the Home page
        public ObservableCollection<Recommendation> recommendations {get;} = new(); 

        // initialses the class HomeTabViewModel
        public HomeTabViewModel() 
        {
            LoadRecommendations();
        }

        // home pages recommendations will be loaded with this function 
        public async Task LoadRecommendations() 
        {
            List<Climb> RecomendedClimds = await ProcessData.CreateRandomClimbs();
            foreach (Climb Recomended in RecomendedClimds) {
                recommendations.Add(new Recommendation(Recomended.RouteName,Recomended.LocationDescription));
            }
            
        }

        // functionalty to the see more feature - adds more to the recommendations list
        public void SeeMore() {
            //System.Console.WriteLine("See More Test");
        }
   }
}