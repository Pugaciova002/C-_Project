using System;
using System.ComponentModel.Design;



namespace Cs_Project.Classes
{
	// can change anything,from table(rows, it's individual parameters) to users 
	internal  class Admin_Rules    // should've inherit Table_Cheangeable ??
	{
		string Admin_Rules_password;     // must be setted on the constructor on the first place
		static Byte Access_Checker = 0;


		public Admin_Rules(string Password)
		{
			Admin_Rules_password = Password;
        }
		 public Byte Checking_Input_Password() {/* comparing it. Setting Access_Checker*/ return 0; }
		
		public void Changing_Password(string New_Password) 
		{
			Admin_Rules_password = New_Password;
		}

		// Checking if user left from the Admin area, in the switch 
		public void Leaving_Admin() { Access_Checker = 0; }

	}
}

