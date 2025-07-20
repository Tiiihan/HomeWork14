//Створіть новий клас Account, що буде означати банківський рахунок. 
//Кожен рахунок має свою назву та початкову сумму грошей на рахунку.
//Стан рахунку не може бути менше за 0. Реалізувати можливість додавати гроші на рахунок та віднімати гроші з рахунку.
//Реалізувати можливість отримати поточний стан рахунку, але не змінювати його напряму.

using HW14;

Client firstClient = new Client("Yuliia", "Tykhovska", 1488);
Client secondClient = new Client("Yura", "Mamash", 1352);

Account accountOfFirstClient = new Account(firstClient, 100);
Account accountOfSecondClient = new Account(secondClient, 100);

List<Account> accounts = new List<Account>();
accounts.Add(accountOfFirstClient);
accounts.Add(accountOfSecondClient);

int userChoice = 0;

bool isEnd = true;

while (isEnd)
{
    Console.WriteLine("To create account enter 1\nTo enter account enter 2\nTo exit enter 3");
	userChoice = int.Parse(Console.ReadLine());
	
	switch ((UserChoice)userChoice)
	{ 
		case UserChoice.CreateAccount:
			accounts.Add(Account.CreateAccount());
			break;
		case UserChoice.EnterToAccount:
            Console.Write("Enter your pinCode: ");
			int userPinCode = int.Parse(Console.ReadLine());

			foreach (var account in accounts)
			{
				if (account.Client.IsCorrectPinCode(userPinCode))
				{
					//викликаємо підменю якось
					AccountService.ShowAccountPosibilities(account);
					break;
				}
			}
			break;
		case UserChoice.Exit:
			isEnd = false;
			break;
	}
}


