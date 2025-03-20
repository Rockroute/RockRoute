using System.Collections.Generic; //to use List
using RockRoute.enums;

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
        
        private static void doesExist(string email)
        {
            //status status = status.Account_Exist
        }
        public static login_Status CreateAccount()
        {
            return(login_Status.Account_Exist);

        }

        public static void LoginAccount(string email, string password)
        {




        }
        




    }

}