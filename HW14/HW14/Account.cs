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
		private decimal balance;
		public Client Client { get; set; }
		public decimal Balance => balance;
		public Account(Client client, decimal initialBalance)
		{
			Client = client;
			this.balance = initialBalance;
		}

		public void AddMoney(decimal sumToAdd)
		{
			if (sumToAdd < 0)
				Console.WriteLine("Sum to add can`t be less than zero");
			else balance += sumToAdd;
		}

		public void WithdrawMoney(decimal sumToWithdraw)
		{
			if (sumToWithdraw > Balance)
				Console.WriteLine("Sum to withdraw can`t be greater than your current balance");
			else balance -= sumToWithdraw;
		}

		public void GetCurrentBalance() => Console.WriteLine("Current balance: " + Balance);
	}
}