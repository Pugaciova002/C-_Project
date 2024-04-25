using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cont;

namespace Tabel
{
    public class Tabel_Afisare
    {
        private const int NR_MAX_ACCAUNTURI = 500;

        public Account[] Rent_Entity { get; set; }
        public int Count_Rent_Entity { get; set; }

        private static int Temp_ID = 0;
        public int []ID { get; set; }


        public Tabel_Afisare()
        {
            Rent_Entity = new Account[NR_MAX_ACCAUNTURI];
            Count_Rent_Entity = 0;
            ID = new int[NR_MAX_ACCAUNTURI];
        }

        public void AddRent_Entity(Account NewEntity)    // de verificat daca deja exista
        {
                if (Count_Rent_Entity < NR_MAX_ACCAUNTURI)
                {
                    Rent_Entity[Count_Rent_Entity] = new Account(NewEntity);

                    Count_Rent_Entity++;
                    ID[Temp_ID] = Temp_ID + 1;
                    Temp_ID++;
                    
                }
        }

        

        public void Update_for_Regiune(Account ac)
        {
            int temp = Count_Rent_Entity - 1;
           
                Rent_Entity[temp] = new Account(ac);
            

        }



        public void Update_Tabel(Account[] ac)
        {
            Temp_ID = 0;
            Count_Rent_Entity = ac.Length;
            for (int i = 0; i < Count_Rent_Entity; i++)
            {
                ID[i] = Temp_ID + 1;
                Temp_ID++;
                Rent_Entity[i] = new Account(ac[i]);
            }

        }


        public Account Get_Info(int Count)    // Must be present in Consola || if Unic_User_ID != null
        {

            if (Rent_Entity[Count] != null && Rent_Entity[Count].Unic_User_ID != null)    // also to chech if present in Black_List         
            {
                return Rent_Entity[Count];
            }
            return null;
        }

        //     Find area

        private Account Failure = null;

        public Account Cautare_ID(int ID,int i)
        {
                if (Rent_Entity[i].Prenume != null)
                {
                    for (int j = 0; j < Temp_ID; j++ )

                    if (this.ID[j] == ID)
                    {
                        return new Account(Rent_Entity[i]);          //  On FIND methods , return copy of the object
                    }
                }
            return new Account(Failure);
        }

        public Account Cautare_Nume(string Nume, int i)
        {
            if (Rent_Entity[i].Nume != null)
            {
                if (Rent_Entity[i].Nume.Equals( Nume) )
                {
                    return new Account(Rent_Entity[i]);
                }
            }
            return new Account(Failure);
        }

        public Account Cautare_Prenume(string Prenume, int i)
        {
            if (Rent_Entity[i].Prenume != null)
            {
                if (Rent_Entity[i].Prenume.Equals( Prenume))
                {
                    return new Account(Rent_Entity[i]);
                }
            }
            return new Account(Failure);
        }

        public Account Cautare_Lot(int Loturi, int i)
        {
            if (Rent_Entity[i].Lotul != null)
            {
                if (Rent_Entity[i].Lotul == Loturi)
                {
                    return new Account(Rent_Entity[i]);
                }
            }
            return new Account(Failure);
        }


        //  Admin only  Methods   // for future

        public void Sterge_Rent_Entity(int? Unic_ID)          //Apar erori din cauza ca ID-ul nu este rearanjat
        {
            for (int i = 0; i < Count_Rent_Entity; i++)
            {
                if (Rent_Entity[i].Unic_User_ID == Unic_ID)
                {
                    Rent_Entity[i] = null;
                    Count_Rent_Entity--;
                }
            }
        }



    }
}
