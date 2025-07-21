using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW14
{
	internal class AccountManager
	{
		private static List<Account> accounts = new List<Account>();
		public static Client CreateClient()
		{
			string firstName = "";
			string lastName = "";
			string pinCode = "";

			Console.Write("Enter firstName: ");
			firstName = Console.ReadLine();

			Console.Write("Enter lasttName: ");
			lastName = Console.ReadLine();

			do
			{
				Console.Write("Create your pinCode, it should have 4 integers: ");
				pinCode = Console.ReadLine();
			}
			while (!Client.IsValidPinCode(pinCode));

			return new Client(firstName, lastName, pinCode);
		}
		public static Account CreateAccount()
		{
			Client newClient = CreateClient();

			bool isValidValue = false;
			decimal initialBalance = 0;

			while (!isValidValue)
			{
				Console.Write("Enter initial balance: ");
				isValidValue = decimal.TryParse(Console.ReadLine(), out initialBalance);

				if (initialBalance < 0)
				{
					isValidValue = false;
					Console.WriteLine("Account balance can`t be less than zero");
				}
			}

			Console.WriteLine("The account has been successfully created, you can now log in.");

			return new Account(newClient, initialBalance);
		}
		public static void AddAccountToList() => accounts.Add(CreateAccount());
		public static void ShowAccountPosibilities(Account account)
		{
			bool isExit = false;
			int userChoice = 0;

			while (!isExit)
			{
				SubMenu(account);

				if (!IsUserChoiceCorrect(out userChoice, true))
					continue;

				switch ((AccountMenu)userChoice)
				{
					case AccountMenu.AddMoney:
						Console.Write("Enter the amount you want to add: ");
						decimal sumToAdd = decimal.Parse((Console.ReadLine()));
						account.AddMoney(sumToAdd);
						break;
					case AccountMenu.WithdrawMoney:
						Console.Write("Enter the amount you want to withdraw: ");
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
		public static void FindAccount()
		{
			if (accounts.Count == 0 || accounts == null)
			{
				Console.WriteLine("No accounts created yet");
				return;
			}

			bool isAccountExists = false;
			int attempts = 3;

			while (!isAccountExists)
			{
				Console.Write("Enter your pinCode: ");
				string userPinCode = Console.ReadLine();

				foreach (var account in accounts)
				{
					if (account.Client.IsCorrectPinCode(userPinCode))
					{
						//викликаємо підменю
						ShowAccountPosibilities(account);
						isAccountExists = true;
						return;
					}
				}

				attempts--;

				if (attempts == 0)
				{
					isAccountExists = true;
					Console.WriteLine("\nYou can`t enter\n");
				}
				else Console.WriteLine($"There is no such account or you entered worng pincode, you have {attempts} attempts");
			}
		}
		public static void MainMenu()
		{
			Console.WriteLine("\nTo create account, enter 1\nTo log in, enter 2\nTo exit, enter 3");
		}
		public static void SubMenu(Account account)
		{
			Console.WriteLine($"\nWelcome, {account.Client.FirstName} {account.Client.LastName}");
			Console.Write("To add money, enter 4\nTo withdraw money, enter 5\n" +
						  "To see current balance, enter 6\nTo exit enter 7\n");
		}
		public static bool IsUserChoiceCorrect(out int userChoice, bool isSubMenu)
		{
			Console.Write("\nYour choice: ");

			bool isValidInput = false;

			isValidInput = int.TryParse(Console.ReadLine(), out userChoice);

			if (isSubMenu)
			{
				if (userChoice < (int)AccountMenu.AddMoney || userChoice > (int)AccountMenu.Exit)
					isValidInput = false;

				return isValidInput;
			}
			else
			{
				if (userChoice < (int)UserChoice.CreateAccount || userChoice > (int)UserChoice.Exit)
					isValidInput = false;

				return isValidInput;
			}
		}
	}
}
