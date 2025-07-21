//Створіть новий клас Account, що буде означати банківський рахунок. 
//Кожен рахунок має свою назву та початкову сумму грошей на рахунку.
//Стан рахунку не може бути менше за 0. Реалізувати можливість додавати гроші на рахунок та віднімати гроші з рахунку.
//Реалізувати можливість отримати поточний стан рахунку, але не змінювати його напряму.

using HW14;

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
			AccountManager.AddAccountToList();
			break;
		case UserChoice.EnterToAccount:
			AccountManager.FindAccount();
			break;
		case UserChoice.Exit:
			isEnd = false;
			break;
	}
}