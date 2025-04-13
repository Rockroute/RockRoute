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

        private static void CreateNewUsername(string InputName)
        {
            //FirstHalf = first 8 characters of InutName
            //Second Half = 000
            //While (theNewUserName = FirstHalf + string(secondHalf).doesIdExist) == false
            //If the usrename exist, Add 1 digit to the three digit code
            //secondHalf += 1
            //end while
            //return theNewUserName //If the username doesnt exist then return the newUsername


        }

        public async static Task<User> findUserFromEmail(string InputEmail) //Works
        {
            //Input email, Returns the User
            List<User> retrievedUsers = await API_Users.GetAllUsersAsync("api/UsersDB");
            if (retrievedUsers.Count > 0)
            {
                //If user do exist, then go through all
                foreach (var oneUser in retrievedUsers)
                {
                    //System.Console.WriteLine(oneUser.Email.ToLower());
                    if (oneUser.Email.ToLower() == InputEmail.ToLower())
                    {
                        return (oneUser);
                    }
                }

            }
            else
            {
                System.Console.WriteLine("No Users not found");
            }
            //If no users or No users match
            return (null);


        }

        private async static Task<bool> doesIdExist(string InputUserName) //Works
        {
            List<User> retrievedUsers = await API_Users.GetAllUsersAsync("api/UsersDB");
            if (retrievedUsers.Count > 0)
            {
                //If user do exist, then go through all

                foreach (var oneUser in retrievedUsers)
                {
                    System.Console.WriteLine(oneUser.UserId);
                    if (oneUser.UserId == InputUserName)
                    {
                        return (true);
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
        private async static Task<bool> doesEmailExist(string InputEmail)
        {
            List<User> retrievedUsers = await API_Users.GetAllUsersAsync("api/UsersDB");
            if (retrievedUsers.Count > 0)
            {
                //If user do exist, then go through all

                foreach (var oneUser in retrievedUsers)
                {
                    System.Console.WriteLine(oneUser.Email.ToLower());
                    if (oneUser.Email.ToLower() == InputEmail.ToLower())
                    {
                        return (true);
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

            string newUserID = input_Name; //Replace this with the function//Temp place the Name their
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

        public static async Task<login_Status> LoginAccount(string InputEmail, string inputPassword) //This all works
        {
            bool doesExist = await doesEmailExist(InputEmail.ToLower());
            if (!doesExist)
            {
                return login_Status.Account_Does_Not_Exists;
            }

            User loginUser = await findUserFromEmail(InputEmail.ToLower());


            if (loginUser.Email.ToLower() == InputEmail.ToLower())
            {
                if (loginUser.Password == inputPassword)
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