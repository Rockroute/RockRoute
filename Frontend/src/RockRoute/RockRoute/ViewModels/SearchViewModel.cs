using RockRoute.Classes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ReactiveUI;

namespace RockRoute.ViewModels
{
    public class SearchViewModel : ReactiveObject
    {
        public ObservableCollection<string> ListOfClimbs {get;} = new();

        private string _SearchInput;

        public string SearchInput
        {
            get => _SearchInput;
            set => this.RaiseAndSetIfChanged(ref _SearchInput, value);
        }

        public SearchViewModel() 
        {
            LoadClimbs();
        }

        public void LoadClimbs() {
            //needs to get all the climbs names and add then to the collection
            ListOfClimbs.Add("climb1");
            ListOfClimbs.Add("climb2");
            ListOfClimbs.Add("climb3");
            ListOfClimbs.Add("climb1");
            ListOfClimbs.Add("climb2");
            ListOfClimbs.Add("climb3");
            ListOfClimbs.Add("climb1");
            ListOfClimbs.Add("climb2");
            ListOfClimbs.Add("climb3");
        }

        public void SearchClimbs(){
            while (ListOfClimbs.Count > 0) {
                ListOfClimbs.RemoveAt(0);
            }
            // get the route names of all the climbs prefrably in a list
            // search through the list for each instance where it starts with wathever is in SearchInput
            // if they do start with that then add it to ListOfClimbs with ListOfClibs.Add(string);
        
        }
    }
}