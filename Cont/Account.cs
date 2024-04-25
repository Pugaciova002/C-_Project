using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


// s-ar putea de facut doar o functie globala in clasa Account, ce ar verifica Key_Access, in locul crearii unei alte clase pentru aceasta
// si prin switch de ales optiunea, dar va fi buna aceasta varianata ? 




// Null for DateTime is DateTime.MinValue

namespace Cont
{

    [Flags]
    public enum Tip_Persoana
    {
        Nedefinit = 0,
        Businessman = 1 << 0,
        Muncitor = 1 << 1,
        Somer = 1 << 2,
        Lucrator_de_stat = 1 << 3,
        Veteranul_Razboiului = 1 << 4
    }

    public class Regiunea
    {
        [Flags]
        public enum Suceava
        {
            Nedefinit = 0,
            Scheia = 1 << 0,
            Moara = 1 << 1,
            Ipotesti = 1 << 2,
            Salcea = 1 << 3,
            Adancata = 1 << 4,
            Mitocu_Dragomirnei = 1 << 5,
            Patrauti = 1 << 6

        }
        [Flags]
        public enum Botosani
        {
            Nedefinit = 0,    // posibil de vazut cum de primit dicatrice de la tastatura, pentru a nu se inlocui toate cu '?'
            Adaseni = 1 << 0,
            Albesti = 1 << 1,
            Avrameni = 1 << 2,
            Blandesti = 1 << 3,
            Broscauti = 1 << 4,
            Braesti = 1 << 5,
            Baluseni = 1 << 6,
            Concesti = 1 << 7,
            Copalau = 1 << 8,
            Cordareni = 1 << 9,
        }
    }


    public class Lista_Chirii
    {
        public const int Max_Nr_Inchirieri = 100;
        public Regiunea.Suceava Suc { set; get; }
        public Regiunea.Botosani Bot { set; get; }

       public DateTime Start_Rent { set; get; }
        public DateTime End_Rent { set; get; }
        public Lista_Chirii()
        {
            Regiunea.Suceava Suc = Regiunea.Suceava.Nedefinit;
            Regiunea.Botosani Bot = Regiunea.Botosani.Nedefinit;

            DateTime Start_Rent = DateTime.MinValue;
            DateTime End_Rent = DateTime.MinValue;
        }
        public Lista_Chirii(Lista_Chirii copy)
        {
            Suc = copy.Suc;
            Bot = copy.Bot;
            Start_Rent = copy.Start_Rent;
            End_Rent = copy.End_Rent;
        }
        public Lista_Chirii(Regiunea.Suceava suc, Regiunea.Botosani bot, DateTime start_rent, DateTime end_rent, Lista_Chirii[] liste)  // De finisat in viitor
        {

            int Size = 0;
            if (liste != null)
            {
                Size = liste.Count(lista => lista != null);
            }

            // verificare pentru ca datele de arenda sa nu se intersecteze . Implementare definitiva in viitor daca va fi timp
            /*   for (int i = 0; i <  Size; i++)              
               {
                   if (!( Suc == suc && Bot == bot && (start_rent >= Start_Rent && end_rent <= End_Rent) ) )
                   {
                       Suc = suc;
                       Bot = bot;
                       Start_Rent = start_rent;
                       End_Rent = end_rent;

                   }
               }*/
        }


        // Enum Input :  Regiune1,Regiune2,Regiune3 ][  DataTime Input : 23.5.2023

        public bool Schimbare_Date(string Reg_Suceava, string Reg_Botosani, string Start, string End)
        {
            string[] Reg_temp = Reg_Suceava.Split(',');
            Regiunea.Suceava temp_Suc;
            bool Verificare = true;

            foreach (string s in Reg_temp)
            {
                Verificare = Regiunea.Suceava.TryParse(s, out temp_Suc);

                if (Verificare == false)
                {
                    return Verificare;   // false
                }
                Suc |= temp_Suc;
            }
            // The string is resetting itself

            Reg_temp = Reg_Botosani.Split(',');

            Regiunea.Botosani temp_Bot;

            foreach (string s in Reg_temp)
            {
                Verificare = Regiunea.Botosani.TryParse(s, out temp_Bot);

                if (Verificare == false)
                {
                    return Verificare;    // false
                }
                Bot |= temp_Bot;
            }

            DateTime temp_St_En;

            Verificare = DateTime.TryParse(Start, out temp_St_En);
            if (Verificare == false) {return Verificare;}         // false
            Start_Rent = temp_St_En;


            Verificare = DateTime.TryParse(End, out temp_St_En);
            if (Verificare == false) { return Verificare; }       // false
            End_Rent = temp_St_En;

            return Verificare;   // True
        }
    }




        public class Account
        {
            public int nr_Inchirieri;
            
            public Lista_Chirii[] lst;

            public Lista_Chirii[] LST { set; get; }



            bool Key_Access = false;

            private static int User_temp_ID = int.MaxValue;  // Used to store the previous ID

            public int? Unic_User_ID { set; get; }   // can't be changed

            public string Login { get; set; }
            public string Password { get; set; }

        //  2024-03-28
            public DateTime Data_Nastere;

            public string Prenume { get; set; }
            public string Nume { get; set; }

            public string cnp;                  // Can contain only 13 number Max

            public string CNP
            {
                get { return cnp; } // Error for Length != 13 digits 

                set
                {
                    if (value != null)
                    {
                        if (value.Length != 13 || !(value.All(c => c >= '0' && c <= '9')))
                        {
                            cnp = "-2";   // error code
                            return;
                        }
                    }
                    cnp = value;
                    return;
                }
            }
            public int? Lotul { get; set; }    // de facut vector

            public string Adresa { get; set; }
            //       Methods

            public Account(string Linia_1,string Linia_2)
            {

            --User_temp_ID;

            Unic_User_ID = User_temp_ID;

            this.lst = new Lista_Chirii[Lista_Chirii.Max_Nr_Inchirieri];

                string[] temp_linia_1 = Linia_1.Split(new char[] { ' ' }, 8);

                    int lot;
                    bool convert = Int32.TryParse(temp_linia_1[6], out lot);
                    this.Lotul = lot;
                Schimbare_Date(temp_linia_1[0], temp_linia_1[1], temp_linia_1[2], temp_linia_1[3], temp_linia_1[4], temp_linia_1[5], lot, temp_linia_1[7]);

                string[] temp_linia_2 = Linia_2.Split(new char[] {' ' }, 4);

                Adaugare_Inchiriere(temp_linia_2[0], temp_linia_2[1], temp_linia_2[2], temp_linia_2[3]);

            }


            void Schimbare_Date(string Login = null, string Password = null, string cnpset = null, string Birth_Date = null, string Person_First_Name = null, string Person_Second_Name = null,  int? Lotul = null, string Adresa = null)
            {
                //this.regiunea = Regiunea.Suceava ;
                this.Password = Password;
                this.Login = Login;
                this.Prenume = Person_First_Name;
                this.Nume = Person_Second_Name;
                this.CNP = cnpset;
                this.Lotul = Lotul;
                this.Adresa = Adresa;
                
                //bool success = DateTime.TryParse(Birth_Date, out this.Data_Nastere);  // in viitor de implementat exceptii
            }
            public Account(string Login = null, string Password = null, string cnpset = null, string Birth_Date = null, string Person_First_Name = null, string Person_Second_Name = null, int? Lotul = null, string adresa = null)
            {
            this.lst = new Lista_Chirii[Lista_Chirii.Max_Nr_Inchirieri];
            nr_Inchirieri = 0;
            Key_Access = true;

                --User_temp_ID;

                Unic_User_ID = User_temp_ID;
                Schimbare_Date(Login, Password, cnpset, Birth_Date, Person_First_Name, Person_Second_Name, Lotul, adresa);
                // out este folosit pentru a transmite adresa argumentului,nu doar valoarea sa
            }
            public Account()
            {
            nr_Inchirieri = 0;
                Key_Access = true; Data_Nastere = DateTime.MinValue; --User_temp_ID; Unic_User_ID = User_temp_ID; Password = Login = Prenume = Nume = CNP = Adresa = null; Lotul = null;
                lst = new Lista_Chirii[Lista_Chirii.Max_Nr_Inchirieri];
            }
            //   DateTime.MinValue  means  no information 

            public Account(Account copy)
            {
                this.Key_Access = copy.Key_Access;
                this.Password = copy.Password;
                this.Login = copy.Login;
                this.Prenume = copy.Prenume;
                this.Nume = copy.Nume;
                this.CNP = copy.CNP;
                this.Lotul = copy.Lotul;
                this.Adresa = copy.Adresa;
                this.Unic_User_ID = copy.Unic_User_ID;
                this.Data_Nastere = copy.Data_Nastere;
                this.lst = copy.lst;
                this.nr_Inchirieri = copy.nr_Inchirieri;
            }
            bool Intrare_Cont(string login, string password)
            {
                if (login.Equals(Login) && password.Equals(Password) && (password != null) && (login != null))
                { Key_Access = true; }

                return Key_Access;
            }

            void Iesire_Cont()
            {
                Key_Access = false;
            }

            public bool Control_Acces()
            {
                return Key_Access;
            }

            bool SetBirthDay(string Birth_Date)     // To see  if put into BirthDay ( set : )
            {
                bool success = DateTime.TryParse(Birth_Date, out this.Data_Nastere);
                return true;   // report to console if ended with succes or not
            }

            void Stergere_Cont()
            {
                Data_Nastere = DateTime.MinValue; Password = Login = Prenume = Nume = CNP = Adresa = null; Lotul = null; Key_Access = false; Unic_User_ID = null; lst = null;
            }


           public bool Adaugare_Inchiriere(string Reg_Suceava, string Reg_Botosani, string Start, string End)
        {
            lst[nr_Inchirieri] = new Lista_Chirii();
            bool Verificare = lst[nr_Inchirieri].Schimbare_Date(Reg_Suceava, Reg_Botosani, Start, End);

            nr_Inchirieri++;

            return Verificare;
        }

            // Lucru cu fisiere
            private const char SEPARATOR_PRINCIPAL_FISIER = ' ';
        private const char SEPARATOR_SECUNDAR_FISIER = '%';   // pentru regiuni

        public string Fisier_Data()//Login Parola CNP Data_Nasterii Prenume Nume Nr.Lot Adresa  // sa fie posibil de adaugat si Unic_User_ID ??

        {
            string General_Data_Fisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}",
                SEPARATOR_PRINCIPAL_FISIER,
                (Login ?? " NECUNOSCUT "),
                (Password ?? " NECUNOSCUT "),
                (CNP ?? " NECUNOSCUT "),
                 (Data_Nastere.ToString("d")),
                (Prenume ?? " NECUNOSCUT "),
                (Nume ?? " NECUNOSCUT "),
                Lotul.ToString(),
                (Adresa ?? " NECUNOSCUT "),
                SEPARATOR_SECUNDAR_FISIER
                );
            // pana ce doar 1 obiect din lista, in viitor de implementat mai multe
            string Regiuni_Data_Fisier = string.Format("{1}{0}{2}{0}{3}{0}{4}",
                SEPARATOR_PRINCIPAL_FISIER,
                lst[0].Suc.ToString().Replace(", ", ","),
                lst[0].Bot.ToString().Replace(", ", ","),
                lst[0].Start_Rent.ToString("d"),
                lst[0].End_Rent.ToString("d")
                );

            General_Data_Fisier += Regiuni_Data_Fisier;

            return General_Data_Fisier;

            }
        }
}

