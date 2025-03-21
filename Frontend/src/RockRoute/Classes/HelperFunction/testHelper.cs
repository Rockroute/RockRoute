using System.Collections.Generic; //to use List
using RockRoute.enums;
using RockRoute.Classes;
using RockRoute.Models;

namespace RockRoute.Helper
{
    public static class testingHelper
    {
        public static void TestHelpName(string hello)
        {

            System.Console.WriteLine(hello);
        }

        public static void testingList()
        {
            List<string> stringsOfApex = new List<string>();
            stringsOfApex.Add("One");
            stringsOfApex.Add("Two");
            stringsOfApex.Add("Three");
            stringsOfApex.Add("Four");
            stringsOfApex.Remove("One");
            int removeHere = stringsOfApex.IndexOf("Three");
            stringsOfApex.RemoveAt(removeHere);
            //Should Print Two Four
            /*
            Things you can use
            Sort()
            Reverse()
            RemoveAt()
            Remove()
            Insert()
            IndexOf()
            Forrach()
            Contains()
            Add()
            */
            foreach (string item in stringsOfApex)
            {
                System.Console.WriteLine(item);
            }
            //System.Console.WriteLine(stringsOfApex);
        }
    }

    public static class LoginFunctions
    {
        //REPLACE HERE WITH API CALL
        //REPLACE HERE WITH API CALL
        //REPLACE HERE WITH API CALL
        private static User testUser = new User
        {
            UserId = "U2827",
            Name = "Harvey",
            Email = "Email@Email.com",
            Password = "PretendThisIsEncrypted"
        };

        private static void newUserID()
        {
            //This will check exisiting UserIDs and create a new newUserID
        }

        private static bool doesExist(string email)
        {
            //Complete this
            //I need to see what the return of /api/UsersDB/{id} looks like for this
            //and /api/UsersDB
            //need to go through all of them to search for Email,
            //Will be simple but just need to see the return of JSON
            return (true);
        }
        public static login_Status CreateAccount(string email, string password, string checkPassword)
        {
            //Check if already exists
            //Passwords Match ✅
            //Create new UserId 
            //create new instance of user
            //Store the in by using -> /api/UsersDB
            if (password != checkPassword)
            {
                return(login_Status.Passwords_Dont_Match);
            }


            return (login_Status.Account_Does_Not_Exists);
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
                } else 
                {
                    return(login_Status.Incorrect_Details);
                }
            } else
            {
                return(login_Status.Incorrect_Details);

            }



        }





    }

}