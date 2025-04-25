using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;//for a list

using RockRoute.Classes;
using RockRoute.Models;
using RockRoute.ApiCalls;
using RockRoute.enums;


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
        public static void processAndPush()
        {

            string Dir = Directory.GetCurrentDirectory() + "/dataset/dataset_normalised.json"; //Using string the slash may be different for windows
            System.Console.WriteLine("things with data!");
            //List<preProcessedClimb> climbs = new List<preProcessedClimb>();
            //System.Console.WriteLine(Dir);


            foreach (var Oneline in File.ReadLines(Dir)) //each line at a time
            {
                if (!string.IsNullOrWhiteSpace(Oneline)) //if not null or white space
                {

                    var climb = JsonSerializer.Deserialize<preProcessedClimb>(Oneline); //convert into type preProcessedClimb

                    var newLocation = new Location
                    {
                        Lat = Convert.ToDouble(climb.parent_loc[0]),
                        Long = Convert.ToDouble(climb.parent_loc[1])
                        
                    };


                    /*
                    var rating = new CRating
                    {
                        UserID = "TEST",
                        Rating = 5
                    };
                    */

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


                    System.Console.WriteLine(newClimb.Type);
                    System.Console.WriteLine(newClimb.ParentLocation.Lat);


                    //Post the New climb to the API
                    API_Climbs.CreateClimbAsync(newClimb);

                }
            }

        }




    }








}