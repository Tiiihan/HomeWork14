using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HW14
{
	internal class Client
	{
		private readonly int pinCode; 
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public Client(string firstName, string lastName, int pinCode)
		{ 
			FirstName = firstName;
			LastName = lastName;
			this.pinCode = pinCode;
		}

		public bool IsCorrectPinCode(int userInput) => pinCode == userInput;
	}
}
