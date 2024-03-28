using Cont;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabel
{
    public class Black_List
    {
        private const int Nr_Conturi_dis = 100;

        private Securitate_Cont[] Conturi_Blocate { get; set; }
        private int Nr_Blocate { get; set; }
        private string[] cauzele_Blocarii { get; set; }
        private string[] Perioadele_blocarii { get; set; }


        public Black_List()
        {
            Conturi_Blocate = new Securitate_Cont[Nr_Conturi_dis];
            cauzele_Blocarii = new string[Nr_Conturi_dis];
            Perioadele_blocarii = new string[Nr_Conturi_dis];
            Nr_Blocate = 0;
        }

        public void AddCont(Securitate_Cont cont,string cauza_Blocarii,string Perioada_blocarii)
        {
            
            Conturi_Blocate[Nr_Blocate] = cont; Nr_Blocate++;
            Perioadele_blocarii[Nr_Blocate] = Perioada_blocarii;
            cauzele_Blocarii[Nr_Blocate] = cauza_Blocarii;
        }

        public int GetNrBlocate()
        {
            return Nr_Blocate;
        }

        public string Get_Info(int Count)
        {
            if (Conturi_Blocate[Count] != null)
            {
                return $"Nr. {Count}" + Conturi_Blocate[Count].Afisare_Date_Tabel() + $"\n(Perioada Blocarii : {Perioadele_blocarii[Count]} \nCauzele Blocarii : {cauzele_Blocarii[Count]}" ;
            }
            return "";
        }

        public void Stergere_Cont_blocat_ID(int Nr_per) 
        {
            int i = 0;
            for(; i < Nr_Blocate; i++)
            {
                if (i == Nr_per) 
                {
                    Conturi_Blocate[i] = null;
                }   
            }         
            for (; i < Nr_Blocate - i;i++)
            {
                Conturi_Blocate[Nr_Blocate - i + 1] = Conturi_Blocate[Nr_Blocate - i];   // rearanjarea incompleta
            }
        }

    }
}
