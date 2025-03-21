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



        private static bool doesExist(string email)
        {
            //Complete this
            return (true);
        }
        public static login_Status CreateAccount(int input)
        {
            return (login_Status.Account_Does_Not_Exists);
        }

        public static login_Status LoginAccount(string email, string password)
        {
            //First do
            /*
            If doesExist(testUser.Email)
            {

            }else
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