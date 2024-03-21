using System;


namespace Cs_Project.Classes
{

    // Should this be a data base for all users, and to make a separate class for handling them ???

    // 1.Will store info about user accounts && Creating new users
    // 2.Will show info about their status
    // 3.Pulling Requests to rent a region . Those Request are managed in Admin Region
    // 4.

    // Deleting Own Account 
       
    internal class User_Accounts 
    {
        static int User_ID = 0;
        string[] login;
        string[] password;
        DateTime[] Birth_Date;
        string[] Person_First_Name;
        string[] Person_Second_Name;
        long[] CNP;
        string[] Address;



        public User_Accounts()    // to see how to handle overflow of the size
        {
            string[] login = new string[100];
            string[] password = new string[100];
            DateTime[] Birth_Date = new DateTime[100]; ;
            string[] Person_First_Name = new string[100];
            string[] Person_Second_Name = new string[100];
            long[] CNP = new long[100];
            string[] Address = new string[100];
        }


        void Creating_New_Account(string[] _login , string[] _password, DateTime[] Birth_Date, string[] Person_First_Name, string[] Person_Second_Name, long[] CNP, string[] Address) 
        {

            // setting all of them, cheking for possible input mistype . To see how to change DateTime struct 


            // at the end
            User_ID++;
        }


        bool Checikng_Password_Login(string _Login, string _Password) {

        // Checikng every string in login && password arrays

            return false; 
        }




    }
}
