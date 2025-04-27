using RockRoute.Classes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Linq;
using ReactiveUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using RockRoute.Models;
using RockRoute.ApiCalls;

namespace RockRoute.ViewModels
{
    public class SearchViewModel : ReactiveObject
    {
        private List<Climb> AllClimbs = new();

        private ObservableCollection<Climb> _filteredFilteredListOfClimbs = new();
        public ObservableCollection<Climb> FilteredListOfClimbs
        {
            get => _filteredFilteredListOfClimbs;
            set => this.RaiseAndSetIfChanged(ref _filteredFilteredListOfClimbs, value);
        }

        private string _searchInput;
        public string SearchInput
        {
            get => _searchInput;
            set => this.RaiseAndSetIfChanged(ref _searchInput, value);
        }



        public SearchViewModel()
        {
            // Anytime SearchInput property changes this is triggered. Throttling to prevent unnecessary calls which could be an issue for if our dataset is larger.
            // Also ensures that the input has to be distinct from the last and keeps it on the main thread avoiding exceptions.
            this.WhenAnyValue(x => x.SearchInput)
                .Throttle(TimeSpan.FromMilliseconds(300))
                .DistinctUntilChanged() 
                .ObserveOn(RxApp.MainThreadScheduler) 
                .Subscribe(x => FilterClimbs());

            LoadClimbs();
        }

        public async void LoadClimbs()
        {
            List<Climb> climbs = await API_Climbs.GetAllClimbsAsync("api/ClimbsDB");
            AllClimbs = climbs;
            FilterClimbs(); 
        }

        private void FilterClimbs()
        {
            if (string.IsNullOrWhiteSpace(SearchInput))
            {
                FilteredListOfClimbs = new ObservableCollection<Climb>(AllClimbs);
            }
            else
            {
                // Filters climbs based on input, alphanumeric case agnostic.
                var filtered = AllClimbs.Where(c => c.RouteName.StartsWith(SearchInput, StringComparison.OrdinalIgnoreCase)).ToList();
                FilteredListOfClimbs = new ObservableCollection<Climb>(filtered);
            }
        }
    }
}
