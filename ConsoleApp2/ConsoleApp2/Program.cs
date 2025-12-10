using System;

namespace HelloWorld
{
	public class Program
	{
		static int bankBalance = 0;
		static void Deposit()
		{
			Console.Write("Enter Amount to Deposit : ");
			int amount = Convert.ToInt32(Console.ReadLine());
			bankBalance += amount;
			Console.WriteLine("Amount Deposited Successfully...");
		}
		static void WithDraw()
		{
			Console.Write("Enter Amount to Withdraw : ");
			int amount = Convert.ToInt32(Console.ReadLine());
			if (bankBalance >= amount)
			{
				bankBalance -= amount;
				Console.WriteLine("Amount Withdrawed Successfully");
			}
			else
			{
				Console.WriteLine("InSufficient Amount to Transaction..");
			}
		}
		static void CheckBalance()
		{
			Console.WriteLine($"Your Current Bank Balance is : {bankBalance} RS.");
		}

		public static void Main(string[] args)
		{
			int choice;
			do
			{

				Console.WriteLine("Bank Account Switching Menu....");

				Console.WriteLine("1. Deposit");
				Console.WriteLine("2. WithDraw");
				Console.WriteLine("3. Check Balance");
				Console.WriteLine("4. Exit");

				Console.Write("Select Your Choice : ");

				choice = Convert.ToInt32(Console.ReadLine());
				switch (choice)
				{
					case 1:
						Deposit();
						break;
					case 2:
						WithDraw();
						break;
					case 3:
						CheckBalance();
						break;
					case 4:
						Console.WriteLine("Exiting the Program...");
						break;
					default:
						Console.WriteLine("Invalid choice! Please try again.");
						break;
				}
			} while (choice != 4);

		}
		
	}
}