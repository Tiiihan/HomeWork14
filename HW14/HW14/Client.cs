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
		const int pincodeLENGTH = 4;
		private readonly string pinCode; 
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PinCode => pinCode;

		public Client(string firstName, string lastName, string pincode)
		{
			FirstName = firstName;
			LastName = lastName;
			this.pinCode = pincode;
		}

		public bool IsCorrectPinCode(string userInput) => pinCode == userInput;
		public static bool IsValidPinCode(string pincode)
		{
			if (pincode.Length != pincodeLENGTH)
				return false;

			int counter = 0;
			for (int i = 0; i < pincode.Length; i++)
				if (char.IsDigit(pincode[i]))
					counter++;

			if (counter != pincodeLENGTH)
				return false;

			return true;
		}
	}
}
