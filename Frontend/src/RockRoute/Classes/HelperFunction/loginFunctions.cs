using System.Collections.Generic; //to use List
using Newtonsoft.Json;//for JSON serilization
using System.Threading.Tasks;

using RockRoute.enums;
using RockRoute.Classes;
using RockRoute.Models;
using RockRoute.ApiTest;

namespace RockRoute.Helper
{
    public static class LoginFunctions
    {
        //REPLACE HERE WITH API CALL
        //REPLACE HERE WITH API CALL
        //REPLACE HERE WITH API CALL
        private static User testUser = new User
        {
            UserId = "Admin",
            Name = "Admin",
            Email = "Admin@Admin.com",
            Password = "PretendThisIsEncrypted"
        };

        private static void Create_new_UserID()
        {
            //This will check exisiting UserIDs and create a new newUserID
        }

        //Workds
        private async static Task<bool> doesExist(string InputEmail)
        {
            //

            List<User> retrievedUsers = await API_Users.GetAllUsersAsync("api/UsersDB");
            if (retrievedUsers.Count > 0)
            {
                foreach (var oneUser in retrievedUsers)
                {
                    System.Console.WriteLine(oneUser.Email);
                    if (oneUser.Email == InputEmail)
                    {
                        return(true);
                    }
                }

            }
            else
            {
                System.Console.WriteLine("No Users not found");
            }
            //If no users or No users match
            return (false);
        }
        public async static Task<login_Status> CreateAccountFunc(string input_Name, string input_email, string input_Password, string input_CheckPassword)
        {

            //TDO
            //Check if already exists
            //Passwords Match ✅
            //Create new UserId 
            //create new instance of user
            //Store the in by using -> /api/UsersDB

            if (input_Password != input_CheckPassword) //Passwords match
            {
                return (login_Status.Passwords_Dont_Match);
            }

            string newUserID = "5627yh"; //Replace this with the function:
            //create new userID()

            User newUser = new User //Creating a new instance to push to database
            {
                UserId = newUserID,
                Name = input_Name,
                Email = input_email,
                Password = input_Password
            };
            var url = await API_Users.CreateUserAsync(newUser);

            //SEND newUser object into the API
            //if API returns code *** then 

            //else (If API returns code ***)
            //return(login_Status.Error);
            
            return (login_Status.Account_Created);

        }

        public static login_Status LoginAccount(string email, string password)
        {
            //First do something like
            /*
            If not doesExist(testUser.Email)
            {
            return(status.Account_Does_Not_Exists)
            }
            */

            if (testUser.Email == email)
            {
                if (testUser.Password == password)
                {
                    return (login_Status.Successfull_Login);
                }
                else
                {
                    return (login_Status.Incorrect_Details);
                }
            }
            else
            {
                return (login_Status.Incorrect_Details);

            }



        }





    }

}