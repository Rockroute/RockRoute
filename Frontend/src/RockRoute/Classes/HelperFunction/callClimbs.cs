//IGNORE THIS FILE JUST SAVING HERE TEMP
/*
Climb Testclimb = new Climb
        {
            RouteName = "TheRouteName",
            RouteId = "LSOSAY",
            SectorId = "djs8d",
            ParentSector = "ClimbSector",
            Type = climbTypes.Boulder,
            YDS = "V2",
            ParentLocation = (37.733, -119.637),
            LocationDescription = "Description of a climb",
            Protection_Notes = "Bring snacks",
            UserRatings = new List<CRating>()
        };
        private async void DeleteClimb(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

            //This works but there is not error handling
            var status = await API_Climbs.DeleteClimbAsync("LSOSAY");

            System.Console.WriteLine("Delete");
        }
        private async void GetAllClimbs(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            //This works
            System.Console.WriteLine("Get All");

            List<Climb> retrievedClimbs = await API_Climbs.GetAllClimbsAsync("api/ClimbsDB");
            if (retrievedClimbs.Count > 0)
            {
                foreach (var oneClimb in retrievedClimbs)
                {
                    System.Console.WriteLine(oneClimb.RouteName);
                }

            }
            else
            {
                System.Console.WriteLine("No Climbs not found");
            }
        }
        private async void GetAClimb(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

            System.Console.WriteLine("Get A");
            //This works
            Climb retrievedClimb = await API_Climbs.GetClimbAsync("api/ClimbsDB/LSOSAY");
            if (retrievedClimb != null)
            {
                System.Console.WriteLine(retrievedClimb.RouteName);
            }
            else
            {
                System.Console.WriteLine("Climb not found");
            }


        }
        private async void SaveAClimb(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            System.Console.WriteLine("Save A");
            //THIS WORKS
            var url = await API_Climbs.CreateClimbAsync(Testclimb);
        }
        //End of the backend testing stuff, If you want it gone just just do one comments block shown as ->


        private void NeedAccountButton(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var NewWindow = new CreateAccount();
            //NewWindow.WindowState = WindowState.Maximized; //Uncomment this, This is just so i need minimise all the time to see debugger
            NewWindow.Show();
            this.Close();

        }


        */