// See https://aka.ms/new-console-template for more information
using Cs_Project.Classes;

//  To not forget about exceptions


Tabel_Not_changeable Tabel = new Tabel_Not_changeable();
Admin_Rules Admin = new Admin_Rules("KLIO943");



Console.WriteLine("\n 1.Administrare loturi(Admin Rules)\n 2.Tabel afisare vizitatori\n 3.Administrare loturi clienti\n 4. Iesire Program");

Console.WriteLine("\n Dati optiunea dorita:");
string optiune = Console.ReadLine();


switch (optiune)
{
    case "1":
        // afisare tabel, optiuni de modificare sau stergere, optiune de cautare
        Console.WriteLine("\nIntroduceti parola Admin:");
        string INP_PASS = Console.ReadLine();


        if (Admin.Checking_Input_Password(INP_PASS) == false)
            Console.WriteLine("\nAti intodus parola gresita\n");
        else
        {
            Console.WriteLine("1.Administrare loturi\n2. Schimbare parola\n 3.Iesire Admin");
            Console.WriteLine("\n Dati optiunea dorita:");
            string optiune_admin = Console.ReadLine();

            // adding a switch with the corresponding logic 
        }


        break;

    case "2":
        // afisare metodei clasei Tabel_Not_changeable 


        int NR_Rows = Tabel.Get_Nr_Row();

        for (int i = 0; i < NR_Rows; i++)
        {
            Console.WriteLine(Tabel.Info());
        }

        break;

    case "3":

        Console.WriteLine("\n 1.Creare Cont\n 2.Administrarea contului \n 3.Iesire Program \n 4. Meniui Principal");
        Console.WriteLine("\n Dati optiunea dorita:");
        string optiune3 = Console.ReadLine();

        switch (optiune3) { case "1": break; case "2": break; case "3": break; }; // add logic to this

        break;



}