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

        private static async Task<string> CreateNewUsername(string InputName)
        {
            //FirstHalf = first 5 characters of InutName
            //Second Half = 000
            //While (theNewUserName = FirstHalf + string(secondHalf).doesIdExist) == false
            //If the usrename exist, Add 1 digit to the three digit code
            //secondHalf += 1
            //end while
            //return theNewUserName //If the username doesnt exist then return the newUsername
            //Input email, Returns the User
            
            //Will just do increment by 1 the highest, Inefficient but works

            string firstHalf = InputName.Substring(0,3);
            int secondHalf = 1;//If start at zero wont be three digits
            string newUserid = firstHalf + secondHalf.ToString();
            //bool doesNewExist = await doesIdExist(newUserid);
            
            while (await doesIdExist(newUserid))
            {
                secondHalf += 1;
                newUserid = firstHalf + secondHalf.ToString("D3"); //combines both halves and keep 3 digits long
            } 
            
            System.Console.WriteLine("New Username created: " + newUserid);
            return(newUserid);
/*          
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
*/
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
            //The Name is longer than 3 characters
            //Passwords Match ✅
            //Create new UserId 
            //create new instance of user
            //Store the in by using -> /api/UsersDB
            

            if (input_Password != input_CheckPassword) //Passwords match
            {
                return (login_Status.Passwords_Dont_Match);
            }

            bool emailExist = await doesEmailExist(input_email);
            if (emailExist)
            {
                return(login_Status.Account_Already_Exists);
            }

            string newUserID = await CreateNewUsername(input_Name); //Create new username

            User newUser = new User //Creating a new instance to push to database
            {
                UserId = newUserID,
                Name = input_Name,
                Email = input_email,
                Password = input_Password
            };
            
            //TODO: Need to do some error checking here
            var url = await API_Users.CreateUserAsync(newUser); //Push to database

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
                    Program.loggedInUser = loginUser;
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
