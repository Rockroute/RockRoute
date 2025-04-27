using System.Collections.Generic; //to use List
using Newtonsoft.Json;//for JSON serilization
using System.Threading.Tasks;

using RockRoute.enums;
using RockRoute.Classes;
using RockRoute.Models;
using RockRoute.ApiTest;

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
    }
}
