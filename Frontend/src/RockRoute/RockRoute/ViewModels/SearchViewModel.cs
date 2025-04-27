using RockRoute.Classes;
using RockRoute.ApiTest;
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
        private Playlist _selectedPlaylist;
        public Playlist SelectedPlaylist
        {
            get => _selectedPlaylist;
            set => this.RaiseAndSetIfChanged(ref _selectedPlaylist, value);
        }

        private ObservableCollection<Playlist> _userPlaylists = new ObservableCollection<Playlist>();
        public ObservableCollection<Playlist> UserPlaylists
        {
            get => _userPlaylists;
            set => this.RaiseAndSetIfChanged(ref _userPlaylists, value);
        }
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
            loadPlaylists();
        }

        public async void loadPlaylists() {
            while (UserPlaylists.Count > 0) {
                UserPlaylists.RemoveAt(0);
            }
            string path = "api/LogBookDB/"+ Program.loggedInUser.UserId;
            LogBook retrievedLogBook = await API_Logbooks.GetLogbookAsync(path);
            
           //System.Console.WriteLine("going to" + path);
            if (retrievedLogBook.Playlist != null) {
                //System.Console.WriteLine((retrievedLogBook));
                
                foreach (Playlist UserPlaylist in retrievedLogBook.Playlist) {
                    UserPlaylists.Add(UserPlaylist);
                }
                
            }
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
