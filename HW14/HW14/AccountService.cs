using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW14
{
	internal class AccountService
	{
		public static void ShowAccountPosibilities(Account account)
		{ 
			bool isExit = false;
			int userChoice = 0;

			while (!isExit)
			{
				Console.Write("\nEnter what you want to do\nTo add money enter 4\nTo withdraw money enter 5\nTo see current belence enter 6\nTo exit enter 7\n");
				userChoice = int.Parse(Console.ReadLine());

				switch ((AccountMenu)userChoice)
				{
					case AccountMenu.AddMoney:
						Console.Write("Enter sum which you want to add: ");
						decimal sumToAdd = decimal.Parse((Console.ReadLine()));
						account.AddMoney(sumToAdd);
						break;
					case AccountMenu.WithdrawMoney:
						Console.Write("Enter sum which you want to withdraw: ");
						decimal sumToWithDraw = decimal.Parse((Console.ReadLine()));
						account.WithdrawMoney(sumToWithDraw);
						break;
					case AccountMenu.ShowCurrentBalance:
						account.GetCurrentBalance();
						break;
					case AccountMenu.Exit:
						isExit = true;
						break;
				}
			}
		}
	}
}
