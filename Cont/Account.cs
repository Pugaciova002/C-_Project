using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


// s-ar putea de facut doar o functie globala in clasa Account, ce ar verifica Key_Access, in locul crearii unei alte clase pentru aceasta
// si prin switch de ales optiunea, dar va fi buna aceasta varianata ? 

namespace Cont
{
    public class Securitate_Cont 
    {
        private  Account _account;

        public Securitate_Cont(Account account)
        {
            _account = account;
        }

        public string Afisare_Date_Cont()
        {
            if (_account.Control_Acces())
            {
                return _account.Afisare_Date_Cont();
            }

            return "Acces interzis";
        }

        public string Afisare_Date_Cont_Particular(Account cont)
        {
            if (_account.Control_Acces())
            {
                return _account.Afisare_Date_Cont_Particular(cont);
            }

            return "Acces interzis";
        }

        public string Intrare_Cont(string login, string password)
        {
            return _account.Intrare_Cont(login, password);
        }

        public void Iesire_Cont()
        {
            _account.Iesire_Cont();
        }

        public bool Control_Acces()
        {
            return _account.Control_Acces();
        }

        public string Schimabare_Parola(string parola_noua)
        {
            if (_account.Control_Acces())
            {
                _account.Password = parola_noua;
                return "Parola resetata!";
            }
            else
                return "Acces interzis";
        }

        public void Schimabare_Login(string _login_nou)
        {
            if (_account.Control_Acces())
            {
                _account.Login = _login_nou;
            }
        }

        public string Schimbare_Date(string Birth_Date, string Person_First_Name, string Person_Second_Name, long cnp, int Lotul)
        {
            if (_account.Control_Acces())
            {
                Schimbare_Date(Birth_Date, Person_First_Name,  Person_Second_Name, cnp, Lotul);
                return "Date resetate!";
            }
            else
                return "Acces interzis";

        }
        public string Afisare_Date_Tabel()
        {
            return _account.Afisare_Date_Tabel();
        }

        public void Stergere_Cont()
        {
            _account.Stergere_Cont();
        }

        public int? GetID()
        {
            return _account.Unic_User_ID;
        }

        public string GetPrenume()
        {
            return _account.Prenume;
        }

        public string GetNume()
        {
            return _account.Nume;
        }

        public int? GetLotul()
        {
            return _account.Lotul;
        }

        public class Account
        {

            private bool Key_Access = false;

            private static int User_ID = 0;

            internal int? Unic_User_ID = 0;   // can't be changed
            internal string Login { get; set; }
            internal string Password { get; set; }

            //  2024-03-28
            internal DateTime Data_Nastere;

            internal string Prenume { get; set; }
            internal string Nume { get; set; }

            internal string cnp;                  // Can contain only 13 number Max

            internal string CNP
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
            internal int? Lotul { get; set; }

            internal string Adresa {  get; set; }
            //       Methods

            
            internal void Schimbare_Date(string Password,string Login,string Birth_Date, string Person_First_Name, string Person_Second_Name, string cnpset, int Lotul, string Adresa)
            {
                this.Password = Password;
                this.Login = Login;
                this.Prenume = Person_First_Name;
                this.Nume = Person_Second_Name;
                this.CNP = cnpset; 
                this.Lotul = Lotul;
                this.Adresa = Adresa;
                bool success = DateTime.TryParse(Birth_Date, out this.Data_Nastere);  // in viitor de implementat exceptii
            }
            public Account(string Login, string Password, string cnpset, string Birth_Date = null, string Person_First_Name = null, string Person_Second_Name = null , int Lotul = 0, string adresa = null)
            {
                Key_Access = true;
                User_ID++;
                Unic_User_ID = User_ID;
                Schimbare_Date(Password, Login, Birth_Date, Person_First_Name, Person_Second_Name, cnpset, Lotul, adresa);
                // out este folosit pentru a transmite adresa argumentului,nu doar valoarea sa
            }
            public Account()
            {
                Key_Access = true; Data_Nastere = DateTime.MinValue; User_ID++; Unic_User_ID = User_ID ; Password = Login = Prenume = Nume = CNP = Adresa = null; Lotul = null; 
            }
            //   DateTime.MinValue  means  no information 
            internal string Afisare_Date_Cont()
            {
                return $"\n[\nID : {Unic_User_ID ?? -1} \n[ \nPassword : {Password ?? "Nesetat"}  \nLogin : {Login ?? "Nesetat"}  \nData Nasterii : {Data_Nastere}  " +
                       $"  \nPrenume : {Prenume ?? "Nesetat"}  \nNume: {Nume ?? "Nesetat"} \nAdresa: {Adresa ?? "Nesetata"}  \nLotul : {Lotul ?? 0}  \nCNP : {CNP ?? "Nesetat"} \n]\n";
            }
            internal string Afisare_Date_Cont_Particular(Account cont)
            {
                return $"\n[\nID : {Unic_User_ID ?? -1} \n[ \nPassword : {cont.Password ?? "Nesetat"} \nLogin : {cont.Login ?? "Nesetat"}  \nData Nasterii : {cont.Data_Nastere}  " +
                   $"  \nPrenume : {cont.Prenume ?? "Nesetat"}  \nNume: {cont.Nume ?? "Nesetat"} \nAdresa: {Adresa ?? "Nesetata"}  \nLotul : {Lotul ?? 0}   \nCNP : {cont.CNP ?? "Nesetat"} \n]\n";
            }

            public string Afisare_Date_Tabel()
            {
                return $"\n[\nID : {Unic_User_ID ?? -1} \nPrenume : {Prenume ?? "Nesetat"}  \nNume: {Nume ?? "Nesetat"}   \nLotul : {Lotul ?? 0}   \n]\n";
            }


            internal string Intrare_Cont(string login, string password)
            {
                if (login.Equals(Login) && password.Equals(Password) && ( password != null) && (login != null) )
                { Key_Access = true; return "Autentificare reusita!"; }
                else
                { return "Autentificare Esuata!"; }
            }
            internal void Iesire_Cont()
            {
                Key_Access = false;
            }
            public bool Control_Acces()
            {
                return Key_Access;
            }
            internal bool SetBirthDay(string Birth_Date)
            {
                bool success = DateTime.TryParse(Birth_Date, out this.Data_Nastere);
                return success;   // report to console if ended with succes or not
            }

            internal void Stergere_Cont() 
            {
                Data_Nastere = DateTime.MinValue; Password = Login = Prenume = Nume = CNP = Adresa = null; Lotul = null; Key_Access = false; Unic_User_ID = null;  
            }
        }
    }
}
