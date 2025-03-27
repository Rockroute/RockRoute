using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RockRoute.ViewModels 
{
    public class Recommendation 
    {
        public string routeName {get; set;}
        public string imageUrl {get; set;}
        public string routeDescription {get; set;}

        public Recommendation(string name, string image, string description) 
        {
            routeName = name;
            imageUrl = image;
            routeDescription = description;
        }
    }
   
   public class HomeTabViewModel : INotifyPropertyChanged 
   {
        public event  PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Recommendation> recommendations {get;} = new(); 

        public HomeTabViewModel() 
        {
            LoadRecommendations();
        }

        public void LoadRecommendations() 
        {
            recommendations.Add(new Recommendation("silence" +": ","no image","a climb that is one if not the hardest route in the world it has only been sent by a select few people who are regareded as the best climbers in the world.magnus recently did a video about it and it was very entertaining"));
            recommendations.Add(new Recommendation("BofD"+": ","no image","a climb"));
            recommendations.Add(new Recommendation("silence" +": ","no image","a climb"));
            recommendations.Add(new Recommendation("BofD"+": ","no image","a climb"));
            recommendations.Add(new Recommendation("silence" +": ","no image","a climb"));
            recommendations.Add(new Recommendation("BofD"+": ","no image","a climb"));
            recommendations.Add(new Recommendation("silence" +": ","no image","a climb"));
            recommendations.Add(new Recommendation("BofD"+": ","no image","a climb"));
            recommendations.Add(new Recommendation("silence" +": ","no image","a climb"));
            recommendations.Add(new Recommendation("BofD"+": ","no image","a climb"));
        }
   }
}