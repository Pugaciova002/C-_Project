using System;
using System.Collections.Generic;
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
            int ite = 0;
            Securitate_Cont.Account[] ACC = new Securitate_Cont.Account[50];
            Securitate_Cont[] ACCSEC = new Securitate_Cont[50];

            Black_List BLKList = new Black_List();

            Tabel_Afisare Tabel = new Tabel_Afisare();

            int optiunea = 0;
            do {

                Console.WriteLine("1) Creare Cont[Citire de la tastatura] \n 2)Tabel cu Informatii \n 3)Tabel cu conturi blocate\n 4)Iesire ");

                Console.WriteLine("Dati optiunea: ");
                Int32.TryParse(Console.ReadLine(), out optiunea);

                switch (optiunea)
                {
                    case 1:
                        { 
                            ACC[ite] = Citire_Tastatura();
                            ACCSEC[ite] = new Securitate_Cont(ACC[ite]);
                            Tabel.AddCont(ACCSEC[ite]);
                            ite++;
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("\n1.Afisare Tabel\n2.Cautare ID\n3.Cautare Nume\n4.Cautare Prenume\n5.Cautare Loturi\n6.Iesire\nOptiunea:");
                            Int32.TryParse(Console.ReadLine(), out optiunea);

                            switch (optiunea)
                            {
                                case 1:
                                    Afisare(Tabel.GetNrConturi(), Tabel); break;

                                case 2:
                                    Console.WriteLine("\"Dati ID-ul cautat:"); int ID;
                                    Int32.TryParse(Console.ReadLine(), out ID);                     // verificare
                                    CautareID(ID, Tabel, Tabel.GetNrConturi()); break;

                                case 3:
                                    Console.WriteLine("\"Dati Numele cautat:"); string nume = Console.ReadLine();
                                    CautareNume(nume, Tabel, Tabel.GetNrConturi()); break;

                                case 4:
                                    Console.WriteLine("\"Dati ID-ul cautat:"); string prenume = Console.ReadLine();
                                    CautarePrenume(prenume, Tabel, Tabel.GetNrConturi()); break;

                                case 5:
                                    Console.WriteLine("\"Dati Lotul-ul cautat:"); int lot;
                                    Int32.TryParse(Console.ReadLine(), out lot);                     // verificare
                                    Cautare_Lot(lot, Tabel, Tabel.GetNrConturi()); break;
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

                                    Afisare_BLK(BLKList.GetNrBlocate(), BLKList);

                                    break;
                                case 2:
                                    ACC[ite] = Citire_Tastatura_BLK();
                                    ACCSEC[ite] = new Securitate_Cont(ACC[ite]);
                                    Console.WriteLine("Cauza Blocarii: "); string cauza_blocarii = Console.ReadLine(); Console.WriteLine("Perioada Blocarii"); string Perioada_Blocarii = Console.ReadLine();
                                    BLKList.AddCont(ACCSEC[ite], cauza_blocarii, Perioada_Blocarii); ite++;
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
                    case 4: Console.WriteLine("Iesire din program..."); break;
                    default:
                        Console.WriteLine("Nu exista astfel de optiuune!");break;
                } 
            } while (optiunea != 4);
            
   
           /* Securitate_Cont.Account ac3 = new Securitate_Cont.Account("Laar", "Lrea", "32453453423" ,"2024-03-28", "Loh", "Pidor", 3);
            Securitate_Cont ac2 = new Securitate_Cont(ac3);
            

            Securitate_Cont.Account ac1 = new Securitate_Cont.Account("Laar", "Lrea", "5432908643234","2043-42-54","Pidar","Jopa",9,"str. Lasara" );
            ac2 = new Securitate_Cont(ac1);

            Securitate_Cont.Account ac6 = new Securitate_Cont.Account("Laar", "Lrea", "5432908643234", "2043-42-54", "Pidar", "Jopa", 9, "str. Lasara");
            ac2 = new Securitate_Cont(ac6);

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
        public static void CautareID(int? ID, Tabel_Afisare Tabel, int nrConturi)
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
               Console.WriteLine( Tabel.Get_Info(i) );
            }
        }

        public static Securitate_Cont.Account Citire_Tastatura()
        {
            Console.WriteLine("\nIntroduceti Parametrii dupa forma:{ Parola Login Data_Nasterii Prenume Nume CNP Nr.Lot Adresa } separate printr-un spatiu");
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
               
                Securitate_Cont.Account ac1 = new Securitate_Cont.Account(temp_array[0], temp_array[1], temp_array[2], temp_array[3], temp_array[4], temp_array[5], lot, temp_array[7]);
                return ac1;
            }
        }

        public static void Afisare_BLK(int nrConturi, Black_List BLK)
        {
            for (int i = 0; i < nrConturi; i++)
            {
                Console.WriteLine(BLK.Get_Info(i));
            }
        }

        public static Securitate_Cont.Account Citire_Tastatura_BLK()
        {
            Console.WriteLine("\nIntroduceti Parametrii dupa forma:{ Parola Login Data_Nasterii Prenume Nume CNP Nr.Lot Adresa } separate printr-un spatiu");
            string temp = Console.ReadLine();
            string[] temp_array = temp.Split(new char[] { ' ' }, 8);
            int lot;
            bool convert = Int32.TryParse(temp_array[6], out lot);
            if (temp_array.Length > 8 && convert)
            {
                Console.WriteLine("\n Ati introdus nr. gresit de caractere");
                return null;  // brilliant idea | hope it won't break the program one day
            }
            else
            {
                Securitate_Cont.Account ac1 = new Securitate_Cont.Account(temp_array[0], temp_array[1], temp_array[2], temp_array[3], temp_array[4], temp_array[5], lot, temp_array[7]);
                return ac1;
            }
        }

    }
}
