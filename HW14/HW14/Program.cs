//Створіть новий клас Account, що буде означати банківський рахунок. 
//Кожен рахунок має свою назву та початкову сумму грошей на рахунку.
//Стан рахунку не може бути менше за 0. Реалізувати можливість додавати гроші на рахунок та віднімати гроші з рахунку.
//Реалізувати можливість отримати поточний стан рахунку, але не змінювати його напряму.

using HW14;

Client firstClient = new Client("Lana", "DelRey", "1488");
Client secondClient = new Client("Tomas", "Mamash", "1352");

Account accountOfFirstClient = new Account(firstClient, 100);
Account accountOfSecondClient = new Account(secondClient, 100);

List<Account> accounts = new List<Account>();
accounts.Add(accountOfFirstClient);
accounts.Add(accountOfSecondClient);

int userChoice = 0;
bool isEnd = true;

while (isEnd)
{
	AccountManager.MainMenu();

	if (!AccountManager.IsUserChoiceCorrect(out userChoice, false))
		continue;

	switch ((UserChoice)userChoice)
	{ 
		case UserChoice.CreateAccount:
			accounts.Add(AccountManager.CreateAccount());
			break;
		case UserChoice.EnterToAccount:
			AccountManager.FindAccount(accounts);
			break;
		case UserChoice.Exit:
			isEnd = false;
			break;
	}
}