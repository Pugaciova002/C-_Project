using Cont;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabel
{
    public class Black_List      // Afisare  :  Nr_Blocate  Nume  Prenume  Unic_User_ID  Cauza_Blocarii
    {
        private const int Nr_Conturi_dis = 100;

        public Account[] Conturi_Blocate { get; set; }
        public int Nr_Blocate { get; set; }
        public string[] cauzele_Blocarii { get; set; }

        //   public string[] Perioada_Blocarii { get; set; }      Maybe in future
      


        public Black_List()
        {
            Conturi_Blocate = new Account[Nr_Conturi_dis];
            cauzele_Blocarii = new string[Nr_Conturi_dis];
           
            Nr_Blocate = 0;
        }

        public void AddCont(Account cont,string cauza_Blocarii)
        {
            
            Conturi_Blocate[Nr_Blocate] = cont; 
    
            cauzele_Blocarii[Nr_Blocate] = cauza_Blocarii;

            Nr_Blocate++;
        }



        public void Stergere_Cont_blocat_ID(int Nr_per) 
        {
            int i = 0;
            for(; i < Nr_Blocate; i++)        // 0  1  2  | Nr_Blocate = 3  |  1 desired one
            {
                if (i == Nr_per) 
                {
                    Conturi_Blocate[i] = null;
                    break;
                }   
            }         
            for (; i < Nr_Blocate  - 1;i++)    //  i = 0  |  i < 2
            {// 0 1 2
                Conturi_Blocate[ i ] = Conturi_Blocate[ i + 1 ];   // rearanjarea incompleta
                cauzele_Blocarii[ i ] = cauzele_Blocarii[ i + 1];
            }
            Nr_Blocate--;
        }

    }
}
