using System;
using System.ComponentModel.Design;



namespace Cs_Project.Classes
{
	// can change anything,from table(rows, it's individual parameters) to users 
	internal  class Admin_Rules    // should've inherit Table_Cheangeable ??
	{
		string Admin_Rules_password;     // must be setted on the constructor on the first place
		static bool Access_Checker = false;


		public Admin_Rules(string Password)
		{
			Admin_Rules_password = Password;
        }
		 public bool Checking_Input_Password(string Inp_Pass) 
		{
			if (Admin_Rules_password.CompareTo(Inp_Pass) == 0)
			{
				Access_Checker = true;
				return true;
			}
			else
			{ return false; }
		
		}
		
		public void Changing_Password(string New_Password) 
		{
			Admin_Rules_password = New_Password;
		}

		// Checking if user left from the Admin area, in the switch 
		public void Leaving_Admin() { Access_Checker = false; }

	}
}

