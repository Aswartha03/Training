using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp3.Models;

namespace ConsoleApp3.Services
{
    internal class LibraryClass
    {

		 List<Book> books = new List<Book>();
		// services or models
		 public void AddBook()
		 {
			try
			{
				Console.Write("Enter Book Name To Add : ");
				string bookName = Convert.ToString(Console.ReadLine());
				Book newBook = new Book(bookName);
				books.Add(newBook);
				Console.WriteLine("Book Added Successfully.");
				Console.WriteLine();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine();
			}
		}
		public void Borrow()
		{
			Console.Write("Enter The Book Name To Borrow : ");
			string userRequiredBook = Console.ReadLine();
			foreach (Book book in books)
			{
				if (book.title == userRequiredBook && book.isAvailable)
				{
					book.isAvailable = false;
					Console.WriteLine("Book is Borrowed");
					return;
				}
				else if (book.title == userRequiredBook && !book.isAvailable)
				{
					Console.WriteLine("Book is Not Available");
					return;
				}
			}
			Console.WriteLine("Book is not Found");
		}
		public void Return()
		{
			Console.Write("Enter The Book Name To Return : ");
			string userBoorrowedBook = Console.ReadLine();
			foreach (Book book in books)
			{
				if (book.title == userBoorrowedBook)
				{
					book.isAvailable = true;
					Console.WriteLine("Book is Returned");
					return;
				}
			}
			Console.WriteLine("Book is not Found");
		}
		public void DisplayBooks()
		{
			Console.WriteLine("List Of Books : ");
			if (books.Count == 0)
			{
				Console.WriteLine("No Books Are There..");
				return;
			}
			foreach (Book book in books)
			{
				book.GetBookDetails();
			}
			Console.WriteLine();
		}
	}
}
