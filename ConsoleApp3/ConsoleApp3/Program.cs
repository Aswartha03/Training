using System;
using ConsoleApp3.Services;
namespace Library
{
	class Program
	{
		public static void Main(string[] args)
		{
			LibraryClass library = new LibraryClass();
			int userChoice;
			do
			{
				Console.WriteLine("Library Management System");
				Console.WriteLine("1. Add Book");
				Console.WriteLine("2. Borrow Book");
				Console.WriteLine("3. Return Book");
				Console.WriteLine("4. Diplay All Books");
				Console.WriteLine("5. Exit");
				Console.WriteLine();
				Console.Write("Enter Your Choice :");
				userChoice = Convert.ToInt32(Console.ReadLine());
				switch (userChoice)
				{
					case 1:
						library.AddBook();
						break;
					case 2:
						library.Borrow();
						break;
					case 3:
						library.Return();
						break;
					case 4:
						library.DisplayBooks();
						break;
					case 5:
						Console.WriteLine("Exiting The Program");
						break;
					default:
						Console.WriteLine("Invalid Case");
						break;
				}
			} while (userChoice != 5);
		}
	}
}
