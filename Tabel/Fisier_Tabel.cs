using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Cont;
using System.Security.Principal;

namespace Tabel
{
    public class Fisier_Tabel
    {
        private const int NR_MAX_STUDENTI = 100;
        private string Den_Fisier;      


        public Fisier_Tabel(string numeFisier) 
        { 
            this.Den_Fisier = numeFisier;
            // creates the file if it dosen't exist

            Stream Fisier_Read = File.Open(numeFisier, FileMode.OpenOrCreate);
            Fisier_Read.Close();
        }


        public void Creare_Stocare_Accaunt(string First_Line, string Second_Line)
        {
            string Whole = string.Empty;

            Whole += First_Line + '%'+ Second_Line ;

            using (StreamWriter Fisier_Write = new StreamWriter(Den_Fisier, true))
            {
                Fisier_Write.WriteLine(Whole);
            }

            // temp to file

        }


        //Login Parola CNP Data_Nasterii Prenume Nume Nr.Lot Adresa  // sa fie posibil de adaugat si Unic_User_ID ??
        public void Add_Rent_Entity(Account account) 
        {
            using (StreamWriter Fisier_Write = new StreamWriter(Den_Fisier, true))
            {
                Fisier_Write.WriteLine(account.Fisier_Data());
            }
        }

        private const char SEPARATOR_SECUNDAR_FISIER = '%';
        public Account[] GetAccounts (out int NR_OBJS)
        {
            Account[] accounts = new Account[NR_MAX_STUDENTI];


            using (StreamReader Fisier_read = new StreamReader(Den_Fisier))
            {
                string[] Sliced = new string[2];
                string Whole;
                NR_OBJS = 0;

                // citeste cate o linie si creaza un obiect de tip Student
                // pe baza datelor din linia citita
                while ((Whole = Fisier_read.ReadLine()) != null)
                {
                    Sliced = Whole.Split('%');
                    accounts[NR_OBJS++] = new Account(Sliced[0], Sliced[1]);
                }
            }


            Array.Resize(ref accounts, NR_OBJS);

            return accounts;

        }


    }
}
