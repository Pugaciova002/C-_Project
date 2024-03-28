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

        private Securitate_Cont[] conturi { get; set; }
        private int conturiCount { get; set; }


        public Tabel_Afisare()
        {
            conturi = new Securitate_Cont[NR_MAX_ACCAUNTURI];
            conturiCount = 0;
        }

        public void AddCont(Securitate_Cont cont)
        {
            conturi[conturiCount] = cont; conturiCount++; 
        }

        public int GetNrConturi() 
        {
            return conturiCount;
        }

        public string Get_Info(int Count)
        {
            if (conturi[Count] != null)
            {
                return conturi[Count].Afisare_Date_Tabel();
            }
            return "";
        }

        /* public void Sterge_Cont(int? ID)          Apar erori din cauza ca ID-ul nu este rearanjat
         {
             for(int i = 0; i < conturiCount; i++) 
             {
                 if (conturi[i].GetID() == ID)
                 {
                     conturi[i] = null;
                     conturiCount--;
                 }
             }
         }*/

    public string Cautare_ID(int? ID,int i)
        {

            
                if (conturi[i].GetPrenume() != null)
                {
                    if (conturi[i].GetID() == ID)
                    {
                        return Get_Info(i);
                    }
                }
            return "";
        }

        public string Cautare_Nume(string Nume, int i)
        {
            if (conturi[i].GetPrenume() != null)
            {
                if (conturi[i].GetNume().Equals( Nume) )
                {
                    return Get_Info(i);
                }
            }
            return "";

        }

        public string Cautare_Prenume(string Prenume, int i)
        {
            if (conturi[i].GetPrenume() != null)
            {
                if (conturi[i].GetPrenume().Equals( Prenume))
                {
                    return Get_Info(i);
                }
            }
            return "";

        }

        public string Cautare_Lot(int Loturi, int i)
        {
            if (conturi[i].GetPrenume() != null)
            {
                if (conturi[i].GetLotul() == Loturi)
                {
                    return Get_Info(i);
                }
            }
            return "";

        }


    }
}
