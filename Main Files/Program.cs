// See https://aka.ms/new-console-template for more information
using Cs_Project.Classes;

Console.WriteLine("Hello, World!");


//  To not forget about exceptions


Tabel_Not_changeable Tabel = new Tabel_Not_changeable();

int NR_Rows = Tabel.Get_Nr_Row();

for (int i = 0; i < NR_Rows; i++)
{
    Console.WriteLine(Tabel.Info());
}