using System.Collections.Generic; //to use List
using Newtonsoft.Json;//for JSON serilization
using System.Threading.Tasks;

using RockRoute.enums;
using RockRoute.Classes;
using RockRoute.Models;
using RockRoute.ApiTest;
using System;

namespace RockRoute.Helper
{
    public static class LogBookFunctions
    {


        public async static Task<LogBook> findLogbookFromId(string InputUserId) //Works
        {
            //Input userid, Returns the User
            List<LogBook> retrievedLogbook = await API_Logbooks.GetAllLogbooksAsync("api/LogbookDB");
            if (retrievedLogbook.Count > 0)
            {
                //If user do exist, then go through all
                foreach (var oneLogbook in retrievedLogbook)
                {
                    ////System.Console.WriteLine(oneUser.Email.ToLower());
                    if (oneLogbook.UserId.ToLower() == InputUserId.ToLower())
                    {
                        return (oneLogbook);
                    }
                }

            }
            else
            {
                //System.Console.WriteLine("No Users not found");
            }
            //If no users or No users match
            return (null);

        }

        public async static Task<bool> newPlaylist(string InputUserId, string playlistName, List<string> collabIds)
        {
            var logbook = await LogBookFunctions.findLogbookFromId(InputUserId);

            List<string> NewCollabID = collabIds;
            if (NewCollabID == null)
            {
                NewCollabID = new List<string> { InputUserId };
            }


            if (logbook == null)
            {
               //System.Console.WriteLine("Logbook not exists!!! but will make it now");

                var NewActivity = new Activity(
                Name: "Activity",
                Date: DateTime.Now,
                Notes: "Notes"
                );


                var NewPlaylist = new Playlist
                {
                    Name = playlistName,
                    CreatorID = InputUserId,
                    CollabID = NewCollabID,
                    ListOfRoute_ID = new List<string> { "Example" },
                    PlaylistPicture = "image_url_here"
                };


                var NewRoute = new CRoute
                {
                    RouteID = "Example",
                    CompletedDate = DateTime.Now,
                    PartnerID = new List<string> { InputUserId },
                    Attempts = 1,
                    IsOnSite = true,
                    Notes = "Note"
                };



                var NewlogBook = new LogBook
                {
                    UserId = InputUserId,
                    RouteId = "TEST",
                    Playlist = new List<Playlist> { NewPlaylist },
                    Route = new List<CRoute> { NewRoute },
                    Activity = new List<Activity> { NewActivity }
                };


                //Then save the new logbook
                try
                {
                    await API_Logbooks.CreateLogbookAsync(NewlogBook);
                   //System.Console.WriteLine("New logbook created!");
                    return true;
                }
                catch (Exception ErrorNOOOO)
                {
                   //System.Console.WriteLine(ErrorNOOOO.Message);
                    return false;
                }
            }
            else
            {



                var NewPlaylist = new Playlist
                {
                    Name = playlistName,
                    CreatorID = InputUserId,
                    CollabID = NewCollabID,
                    ListOfRoute_ID = new List<string> { "Example" },
                    PlaylistPicture = "image_url_here"
                };

                if (logbook.Playlist == null)
                {
                    logbook.Playlist = new List<Playlist>();
                }
                logbook.Playlist.Add(NewPlaylist);


                try
                {
                    var updatedLogbook = await API_Logbooks.UpdateLogbookAsync(logbook);
                   //System.Console.WriteLine("Logbook updated!!");

                    //System.Console.WriteLine(JsonConvert.SerializeObject(updatedLogbook, Formatting.Indented));

                    return true;
                }
                catch (Exception ErrorNOOOO)
                {
                   //System.Console.WriteLine("Error while updating logbook: " + ErrorNOOOO.Message);
                    return false;
                }


            }







        }




    }
}
