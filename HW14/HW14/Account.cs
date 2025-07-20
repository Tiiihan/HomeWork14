using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HW14
{
	internal class Account
	{
		private decimal initialBalance;
		public Client Client { get; set; }
		public decimal InitialBalance { get => initialBalance;
			set
			{
				if (value < 0)
					throw new ArgumentException("Account balance can`t be less than zero");
				initialBalance = value;
			}
		}

		public Account(Client client, decimal initialBalance)
		{ 
			Client = client;
			InitialBalance = initialBalance;
		}

		public void AddMoney(decimal sumToAdd)
		{ 
			InitialBalance += sumToAdd;
		}

		public void WithdrawMoney(decimal sumToWithdraw)
		{
			if (sumToWithdraw > InitialBalance)
				throw new ArgumentException("Sum to withdraw can`t be greater than your current balance");
			InitialBalance -= sumToWithdraw;
		}

		public void GetCurrentBalance() => Console.WriteLine("Current balance: " + InitialBalance); 
		public static Account CreateAccount()
		{
			Console.Write("Enter firstName: ");
			string firstName = Console.ReadLine();

			Console.Write("Enter lasttName: ");
			string lastName = Console.ReadLine();

			Console.Write("Create your pinCode, it should have 4 integers");
			int pinCode = int.Parse(Console.ReadLine());

			Console.Write("Enter initial balance: ");
			decimal initialBalance = decimal.Parse(Console.ReadLine());

			Client client = new Client(firstName, lastName, pinCode);

			return new Account(client, initialBalance);
		}


	}
}