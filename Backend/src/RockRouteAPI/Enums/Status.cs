namespace RockRoute.enums
{
    public enum login_Status
        {
            Account_Exists, //0
            Account_Already_Exists, //1 //For if the user tries to make a new account with existing email
            Account_Does_Not_Exists, //2
            Incorrect_Details, //3
            Successfull_Login, //4
            Passwords_Dont_Match, //5
            Account_Created, //6
            Error //7 Somethings gone wrong
        }
}