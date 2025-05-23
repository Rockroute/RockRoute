using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;//for a list
using System.Threading.Tasks;


using RockRoute.Classes;
using RockRoute.Models;
using RockRoute.ApiCalls;
using RockRoute.enums;
using RockRoute.Helper;
using RockRoute.ApiTest;





namespace RockRoute.climbData
{

    public class preProcessedClimb //The climb in the dataset
    {

        public string route_name { get; set; }
        public string parent_sector { get; set; }
        public string route_ID { get; set; }
        public string sector_ID { get; set; }
        public string type_string { get; set; }
        public string fa { get; set; }
        public string YDS { get; set; }
        public string Vermin { get; set; }
        public string nopm_YDS { get; set; }
        public string nopm_Vermin { get; set; }
        public string YDS_rank { get; set; }
        public string Vermin_rank { get; set; }
        public string safety { get; set; }
        public List<string> parent_loc { get; set; }
        public List<string> description { get; set; }
        public List<string> location { get; set; }
        public List<string> protection { get; set; }

    }

    class ProcessData
    {
        //List to store all the routenames for when generating playlist
        public static List<string> routeIds = new List<string>();

        private static climbTypes ProcessClimbTypes(string climbType)
        //Process from string to the corresponding enum
        {
            if (climbType == "trad")
            {
                return (climbTypes.Trad);
            }
            if (climbType == "sport")
            {
                return (climbTypes.Sport);
            }
            if (climbType == "boulder")
            {
                return (climbTypes.Boulder);
            }
            else
            {
                return (climbTypes.Unknown);
            }



        }
        private static async Task processAndPush()
        {

            string Dir = Directory.GetCurrentDirectory() + "/dataset/dataset_normalised.json"; //Using string the slash may be different for windows
            ////System.Console.WriteLine("things with data!");
            //List<preProcessedClimb> climbs = new List<preProcessedClimb>();
            ////System.Console.WriteLine(Dir);


            foreach (var Oneline in File.ReadLines(Dir)) //each line at a time
            {
                if (!string.IsNullOrWhiteSpace(Oneline)) //if not null or white space
                {

                    var climb = JsonSerializer.Deserialize<preProcessedClimb>(Oneline); //convert into type preProcessedClimb

                    var newLocation = new Location
                    {
                        Lat = Convert.ToDouble(climb.parent_loc[1]),
                        Long = Convert.ToDouble(climb.parent_loc[0])

                    };


                    /*
                    var rating = new CRating
                    {
                        UserID = "TEST",
                        Rating = 5
                    };
                    */
                    routeIds.Add(climb.route_ID);
                    var newClimb = new Climb //Make a climb to be pushed
                    {
                        RouteName = climb.route_name,
                        RouteId = climb.route_ID,
                        SectorId = climb.sector_ID,
                        ParentSector = climb.parent_sector,
                        Type = ProcessClimbTypes(climb.type_string),
                        YDS = climb.YDS,
                        ParentLocation = newLocation,
                        LocationDescription = climb.description[0],
                        Protection_Notes = climb.protection[0],
                        UserRatings = new List<CRating>()

                    };


                    ////System.Console.WriteLine(newClimb.Type);
                    ////System.Console.WriteLine(newClimb.ParentLocation.Lat);


                    //Post the New climb to the API
                    await API_Climbs.CreateClimbAsync(newClimb);

                }
            }

        }

        public async static Task createAndPushData()
        {

            await processAndPush();


            List<Climb> retrievedClimbs = await API_Climbs.GetAllClimbsAsync("api/ClimbsDB");




            //Creates Accounts
            LoginFunctions.CreateAccountFunc("Harvey", "Harvey@Gmail.com", "1234", "1234");
            LoginFunctions.CreateAccountFunc("Sam", "Sam@Yahoo.com", "Climber1234", "Climber1234");
            LoginFunctions.CreateAccountFunc("Libby", "Libby@Yahoo.com", "Passsword", "Passsword");
            LoginFunctions.CreateAccountFunc("David", "David@Gmail.com", "hde7DN(02-MS98)", "hde7DN(02-MS98)");
            LoginFunctions.CreateAccountFunc("Lilly", "Lilly@Gmail.com", "CatAreOKay", "CatAreOKay");
            LoginFunctions.CreateAccountFunc("Jake", "Jake@Gmail.com", "IloveComputers", "IloveComputers");
            LoginFunctions.CreateAccountFunc("Nate", "Nate@Yahoo.com", "sk8t4Life", "sk8t4Life");
            LoginFunctions.CreateAccountFunc("Kyle", "Kyle@Gmail.com", "liverp00lisG8t", "liverp00lisG8t");
            LoginFunctions.CreateAccountFunc("Seb", "Seb@Gmail.com", "pythonIsBest", "pythonIsBest");
            LoginFunctions.CreateAccountFunc("JohnBox", "JohnBox@Gmail.com", "HaskellIsLitBro", "HaskellIsLitBro");
            LoginFunctions.CreateAccountFunc("Phil", "Phil@Yahoo.com", "IloveApple", "IloveApple");


            Random random = new Random(); //object Random with name random

            //To generate random but slightly realistic activities
            string[] activity = { "Indoor Sport", "Indoor Boulder", "Indoor trad", "Outdoor Sport", "Outdoor Boulder", "Outdoor Trad" };
            string[] workedOn = { "Footwork", "Overhang", "hangboard", "Cardio", "weights", "fingers", "Slab", "dyno", "static" };

            string[] possibleEmails = { "Phil@Yahoo.com", "JohnBox@Gmail.com", "Seb@Gmail.com", "Kyle@Gmail.com", "Harvey@Gmail.com", "Nate@Yahoo.com", "Jake@Gmail.com", "Lilly@Gmail.com", "David@Gmail.com", "Libby@Yahoo.com", "Sam@Yahoo.com" };

            foreach (var MakingForEmail in possibleEmails)
            {
                //Only want one logbook per user
                var user = await LoginFunctions.findUserFromEmail(MakingForEmail); //get the ID of the chosen email


                var NewActivity = new Activity(
                Name: activity[random.Next(0, 5)],
                Date: DateTime.Now,
                Notes: "Worked on " + workedOn[random.Next(0, 8)] + " and " + workedOn[random.Next(0, 8)]
                );



                string[] playListName = { "Cup ", "Crag ", "Modern ", "Classic ", "Fun Day out at ", "France 2026 ", "The Lads ", "Summer ", "Crazy" };

                var collab1 = await LoginFunctions.findUserFromEmail(possibleEmails[random.Next(0, 10)]); //get the ID of the random chosen email
                var collab2 = await LoginFunctions.findUserFromEmail(possibleEmails[random.Next(0, 10)]); //get the ID of the random chosen email

                int index = random.Next(retrievedClimbs.Count);
                string randomClimbID = retrievedClimbs[index].RouteId;
                //System.Console.WriteLine((randomClimbID));

                if (user == null || collab1 == null || collab2 == null)
                {
                    //Skip iteration if null
                    //System.Console.WriteLine(("Skipped"));
                    continue;
                }




                var NewRoute = new CRoute
                {
                    RouteID = randomClimbID,
                    CompletedDate = DateTime.Now,
                    PartnerID = new List<string> { collab1.UserId, collab2.UserId },
                    Attempts = random.Next(0, 50),
                    IsOnSite = true,
                    Notes = "Flashed second attempt!"
                };



                var NewlogBook = new LogBook
                {
                    UserId = user.UserId,
                    RouteId = randomClimbID,
                    Playlist = new List<Playlist>(), //Blank as it gets updated later
                    Route = new List<CRoute> { NewRoute },
                    Activity = new List<Activity> { NewActivity }
                };

                try
                {
                    await API_Logbooks.CreateLogbookAsync(NewlogBook);
                    //System.Console.WriteLine("Logbook created!");
                }
                catch (Exception ErrorNOOOO)
                {
                    //System.Console.WriteLine(ErrorNOOOO.Message);
                }




                for (int i = 0; i < 10; i++)
                {
                    string randomName = playListName[random.Next(0, 9)] + " " + playListName[random.Next(0, 9)];



                    var collabIds = new List<string> { collab1.UserId, collab2.UserId };

                    bool doesWork = await LogBookFunctions.newPlaylist(user.UserId, randomName, collabIds);

                    if (!doesWork)
                    {
                        Console.WriteLine($"Failed to create playlist '{randomName}' for user {user.UserId}");
                    }
                }








            }




        }

        public static async Task<List<Climb>> CreateRandomClimbs()
        {
            Random rand = new Random();
            int randomNumber;
            List<Climb> AllClimbs = await API_Climbs.GetAllClimbsAsync("api/ClimbsDB");
            List<Climb> RandomClimbs = new List<Climb>();

            for (int i = 0; i <= 10; i++)
            {
                randomNumber = rand.Next(AllClimbs.Count);
                RandomClimbs.Add(AllClimbs[randomNumber]);
            }


            return RandomClimbs;
        }

    }








}