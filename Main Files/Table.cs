using System;
using System.Security.Cryptography.X509Certificates;


namespace Cs_Project.Classes
{
    internal class Tabel_Not_changeable 
    {
        protected    // they should be protected
            static int NR_Row;
            int[] ID_User;        // Not shown, only on Tabel_Changeable mode
            string[] Regions;
            int[] Nr_of_Lots;   // from that region
            string[] Name_Lots;
            string[] Person_First_Name;
            string[] Person_Second_Name;
            int[] Price_Month;
            int[] Rent_Period;   // days
            DateTime[][] Rent_Range;     //  [][2] - for Start date && finish date 
            bool[] Paid_YES_NO;
            bool[] Free_YES_NO;

        static int Iterator = 0;

        public Tabel_Not_changeable()            // for test purpose only . Normally, it must not exist
        {
            NR_Row = 4;
            Regions = new string[5];
            for (int i = 1; i < NR_Row + 1; i++)
            { 
                Regions[i] = "fe"; 
            }
        
        
        }   // for test purpose only . Normally, it must not exist

        public int Get_Nr_Row() { return NR_Row; }      // Used for Info() method
        public string Info()
        {   if (Iterator == (NR_Row + 1))
            {
                Iterator = 0;
                return "End of Data";
            }
            else
            {
                Iterator++;
                //return $"{Iterator} | {Regions[Iterator]} | {Nr_of_Lots[Iterator]} | {Name_Lots[Iterator]} | {Person_First_Name[Iterator]} | {Person_Second_Name[Iterator]} | {Price_Month[Iterator]} |  {Rent_Period[Iterator]} |  {Rent_Range[Iterator][0]} -- {Rent_Range[Iterator][1]}  |  {Paid_YES_NO[Iterator]} |  {Free_YES_NO[Iterator]} | ";
                return $"{Iterator} | {Regions[Iterator]}";
            }
        }

    }

    internal class Tabel_Changeable // it must inherit Tabel_Not_changeable
    {
        // setting the number of the max number of the lot int Nr_of_Lotss;
        // Constains Setters 
    }
}
