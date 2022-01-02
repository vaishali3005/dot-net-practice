using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StrArray
{
	internal class StringAry
	{
        private static int i;

        public static void Main(string[] args)
		{
			string Fname , Lname ;

			int i =100;
			string[] Name1 = new string[i];
			//string ans;
			//l1:




			for ( i = 0; i < Name1.Length; i++)

			{
				Console.WriteLine("Do you want to Enter user (Y/N)");
				string ans = Console.ReadLine();
				if (ans == "y" || ans == "Y")
				{
					Console.WriteLine("Enter your First Name-");
					Fname = Console.ReadLine();
					Console.WriteLine("Enter your Last Name-");
					Lname = Console.ReadLine();
					string FullName = Fname + " " + Lname;
					Name1[i] = FullName;

					//Name[i].add(FullName);
					Console.WriteLine();
					Console.WriteLine(Name1[i]);
				}
				else
				{
					break;

				}

			}
			int n = i;

			for (i = 0; i < n ; i++)

			{
				//Console.WriteLine();
				Console.WriteLine(Name1[i]);
			}
			






		}
	}

}




			
