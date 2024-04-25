using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using Cont;
using Tabel;

//  2024-03-28 pentru DataTime     
//  Model introducere date constructor   Login 123 4320947593023 2000-04-05 Vasile Tarasov 4 str.La

namespace Interfata_de_Comanda
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;


            int Nr_Studenti = 0;   // global iterator, For general info, and blocked accounts
            Account[] ACC = new Account[50] ;
            

            Black_List BLKList = new Black_List();

            Tabel_Afisare Tabel = new Tabel_Afisare();

            Fisier_Tabel Fisier = new Fisier_Tabel(caleCompletaFisier);

            int optiunea = 0;
            do {

                Console.WriteLine("1) Creare Cont[Citire de la tastatura] \n 2)Tabel cu Informatii \n 3)Tabel cu conturi blocate\n 4)Lucru cu fisiere  \n5)Iesire ");

                Console.WriteLine("Dati optiunea: ");
                Int32.TryParse(Console.ReadLine(), out optiunea);

                switch (optiunea)
                {
                    case 1:
                        { 
                            ACC[Nr_Studenti] = Citire_Tastatura();
                            Tabel.AddRent_Entity(ACC[Nr_Studenti]);
                            
                           
                            Console.WriteLine("Doriti Adaugare Regiuni Arendate?: 1 - DA ");
                            Int32.TryParse(Console.ReadLine(), out optiunea);
                            if (optiunea == 1)
                                Adaugare_Regiuni(ACC[Nr_Studenti],Tabel,ACC);
                            Nr_Studenti++;
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("\n1.Afisare Tabel\n2.Cautare ID\n3.Cautare Nume\n4.Cautare Prenume\n5.Cautare Loturi\n6.Iesire\nOptiunea:");
                            Int32.TryParse(Console.ReadLine(), out optiunea);

                            switch (optiunea)
                            {
                                case 1:
                                    Afisare(Tabel.Count_Rent_Entity, Tabel); break;

                                case 2:
                                    Console.WriteLine("\"Dati ID-ul cautat:"); int ID;
                                    Int32.TryParse(Console.ReadLine(), out ID);                     // verificare
                                    CautareID(ID, Tabel, Tabel.Count_Rent_Entity); break;

                                case 3:
                                    Console.WriteLine("\"Dati Numele cautat:"); string nume = Console.ReadLine();
                                    CautareNume(nume, Tabel, Tabel.Count_Rent_Entity); break;

                                case 4:
                                    Console.WriteLine("\"Dati ID-ul cautat:"); string prenume = Console.ReadLine();
                                    CautarePrenume(prenume, Tabel, Tabel.Count_Rent_Entity); break;

                                case 5:
                                    Console.WriteLine("\"Dati Lotul-ul cautat:"); int lot;
                                    Int32.TryParse(Console.ReadLine(), out lot);                     // verificare
                                    Cautare_Lot(lot, Tabel, Tabel.Count_Rent_Entity); break;
                                case 6:
                                    Console.WriteLine("Iesire din program..."); break;

                                default:
                                    Console.WriteLine("Nu exista astfel de optiuune!"); break;

                            }

                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("\n1.Afisare Tabel cu conturi BLocate\n2.Citire tastatura\n3.Stergere cont blocat\n4.Iesire\nOptiunea:");
                            Int32.TryParse(Console.ReadLine(), out optiunea);

                            switch (optiunea)
                            {
                                case 1:

                                    Afisare_BLK(BLKList.Nr_Blocate, BLKList);

                                    break;
                                case 2:
                                     Citire_Tastatura_BLK(BLKList);
                                    
                                    break;

                                case 3:

                                    Console.WriteLine("Introduceti nr. persoanei:");
                                    int nr;
                                    Int32.TryParse(Console.ReadLine(), out nr);
                                    BLKList.Stergere_Cont_blocat_ID(nr);
                                    break;

                                case 4:
                                    Console.WriteLine("Iesire din program...");
                                    break;

                                default:
                                    Console.WriteLine("Nu exista astfel de optiuune!"); break;
                            }
                            break;  
                        }



                    case 4: 
                        {

                            Console.WriteLine("\n1.Scriere Fisier(Creare Accaunt)\n2.Afisare Fisier(In tabel)\n3.Adaugare Acc\n4.Iesire\nOptiunea:");
                            Int32.TryParse(Console.ReadLine(), out optiunea);

                            switch(optiunea)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("\nIntroduceti Parametrii dupa forma:{ Login Parola CNP Data_Nasterii Prenume Nume Nr.Lot Adresa  } separate printr-un spatiu");
                                        string first_Part = Console.ReadLine();

                                        Console.WriteLine("\nIntroduceti Regiuni Suceava, Botosani separate printr-o virgula, Data start,end, toate separate prin spatiu:");
                                        string secound_Part = Console.ReadLine();
                                        Fisier.Creare_Stocare_Accaunt(first_Part, secound_Part);

                                        Nr_Studenti++;

                                        break;
                                    }
                                case 2:
                                    {
                                       Account[] afisare = Fisier.GetAccounts(out Nr_Studenti);
                                       Tabel.Update_Tabel(afisare);
                                        Afisare(Nr_Studenti, Tabel);
                                            break;
                                    }

                            }

                            break;
                        }

                    case 5: Console.WriteLine("Iesire din program..."); break;

                    default:
                        Console.WriteLine("Nu exista astfel de optiuune!");break;
                } 
            } while (optiunea != 4);
            
   
           /* Account ac3 =new Account("Laar", "Lrea", "32453453423" ,"2024-03-28", "Loh", "Pidor", 3);
            
            

            Account ac1 = new Account("Laar", "Lrea", "5432908643234","2043-42-54","Pidar","Jopa",9,"str. Lasara" );
           

            Account ac6 = new Account("Laar", "Lrea", "5432908643234", "2043-42-54", "Pidar", "Jopa", 9, "str. Lasara");
            

            Tabel.AddCont(ac2);
            Tabel.AddCont(ac2);
            ac2.Iesire_Cont();
                 
            Console.WriteLine(ac2.Intrare_Cont("", ""));
            Console.WriteLine ( ac2.Intrare_Cont("Laar", "Lrea") );
            Console.WriteLine(ac2.Afisare_Date_Cont());

            // Afisare Tabel General

            Afisare(Tabel.GetNrConturi() ,Tabel);

            // Stergere element Tabel
            Console.WriteLine("BLK:");
            BLKList.AddCont(ac2,"loh","9years");
            BLKList.AddCont(ac2, "loh", "9years");
            BLKList.AddCont(ac2, "loh", "9years");
            BLKList.AddCont(ac2, "loh", "9years");
            BLKList.AddCont(ac2, "loh", "9years");

            BLKList.Stergere_Cont_blocat_ID(2);

            Afisare_BLK(BLKList.GetNrBlocate(), BLKList);

            // Cautare Nume
            Console.WriteLine("Cautare Prenume");
            CautarePrenume("Pidar",Tabel,Tabel.GetNrConturi());*/
        }

        public static void Cautare_Lot(int Loturi, Tabel_Afisare Tabel, int nrConturi)
        {
            for (int i = 0; i < nrConturi; i++)
            {
                Console.WriteLine(Tabel.Cautare_Lot( Loturi, i));
            }
        }

        public static void CautarePrenume(string Prenume,  Tabel_Afisare Tabel, int nrConturi)
        {
            for (int i = 0; i < nrConturi; i++)
            {
                Console.WriteLine(Tabel.Cautare_Prenume(Prenume, i));
            }
        }

        public static void CautareNume(string Nume, Tabel_Afisare Tabel, int nrConturi)
        {
            for (int i = 0; i < nrConturi; i++)
            {
                Console.WriteLine(Tabel.Cautare_Nume(Nume,i));
            }
        }
        public static void CautareID(int ID, Tabel_Afisare Tabel, int nrConturi)
        {
            for (int i = 0; i < nrConturi; i++)
            {
                Console.WriteLine(Tabel.Cautare_ID(ID,i));
            }
        }

        public static void Afisare(int nrConturi,Tabel_Afisare Tabel)

        {   
            for(int i = 0; i < nrConturi; i++) 
            {
                Account Temp = new Account(Tabel.Get_Info(i));
                Console.WriteLine($"{Tabel.ID[i]}.    Nume : {Temp.Nume} Prenume : {Temp.Prenume} Lot : {Temp.Lotul} " );

                for (int j = 0; j < Temp.nr_Inchirieri  ; j++)
                {
                    Console.WriteLine($"\tRegiuni Suceava:{Temp.lst[j].Suc}\n\tRegiuni Botosani:{Temp.lst[j].Bot}\n\tData_Start{Temp.lst[j].Start_Rent.ToString("d")}\n\tData_End{Temp.lst[j].End_Rent.ToString("d")}\n");
                }
            }


        }

        public static Account Citire_Tastatura()
        {
            Console.WriteLine("\nIntroduceti Parametrii dupa forma:{ Login Parola CNP Data_Nasterii Prenume Nume Nr.Lot Adresa  } separate printr-un spatiu");
            string temp = Console.ReadLine();
            string[] temp_array = temp.Split(new char[] {' '},8) ;
            int lot;
            bool convert= Int32.TryParse(temp_array[6], out lot);
            if (temp_array.Length > 8 && convert) {
                Console.WriteLine("\n Ati introdus nr. gresit de caractere");
                return null;  // brilliant idea | hope it won't break the program one day
            }
            else
            {
               
                Account ac1 = new Account(temp_array[0], temp_array[1], temp_array[2], temp_array[3], temp_array[4], temp_array[5], lot, temp_array[7]);
                return ac1;
            }
        }

        
        public static void Adaugare_Regiuni(Account ac, Tabel_Afisare Tabel, Account[] acs)
        {

            Console.WriteLine("Introduceti regiunile din Suceava,separate printr-o virgulă [Nedefinit = niciuna] :");
            string[] temp = new string[4];
            temp[0] = Console.ReadLine();
            Console.WriteLine("Introduceti regiunile din Botosani,separate printr-o virgulă [Nedefinit = niciuna] :");
            temp[1] = Console.ReadLine();
            Console.WriteLine("Introduceti Data de începere a închirierii :");
            temp[2] = Console.ReadLine();
            Console.WriteLine("Introduceti Data de încheiere a închirierii :");
            temp[3] = Console.ReadLine();

           bool Verificare = ac.Adaugare_Inchiriere(temp[0], temp[1], temp[2], temp[3]);
            if (Verificare == false)
                Console.WriteLine("Date introduse incorect");


             Tabel.Update_Tabel(acs);
        }




        //   Forbidden area

        public static void Afisare_BLK(int nrConturi, Black_List BLK)   // Afisare  :  Nr_Blocat  Nume  Prenume  Unic_User_ID  Cauza_Blocarii
        {

            for (int i = 0; i < BLK.Nr_Blocate; i++)
            {
                Console.WriteLine($"{i}  {BLK.Conturi_Blocate[i].Nume}  {BLK.Conturi_Blocate[i].Prenume} {BLK.Conturi_Blocate[i].Unic_User_ID}  {BLK.cauzele_Blocarii[i]}");
            }
        }

        public static void Citire_Tastatura_BLK(Black_List BLK)
        {
            Console.WriteLine("\nIntroduceti Parametrii dupa forma:{ Nume Prenume Unic_User_ID Cauzele_Blocarii } separate printr-un spatiu");
            string temp = Console.ReadLine();
            string[] temp_array = temp.Split(new char[] { ' ' }, 5); 

            int User_ID;
            bool convert = Int32.TryParse(temp_array[2], out User_ID);   // to see in future the exception handling

            if (temp_array.Length > 4 && convert)
            {
                Console.WriteLine("\n Ati introdus nr. gresit de cuvinte");
                  // brilliant idea | hope it won't break the program one day
            }
            else
            {
                Account ac1 = new Account(null, null, null, null, temp_array[0], temp_array[1]);
                ac1.Unic_User_ID = User_ID;
              
                BLK.AddCont(ac1, temp_array[3]);
                
            }
        }

    }
}
