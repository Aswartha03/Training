using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3.Models
{
	internal class Book
	{
		public string title;
		public bool isAvailable = true;
		public Book(string bookName)
		{
			title = bookName;
		}
		public void GetBookDetails()
		{
			string available = isAvailable ? "Avaialable" : "Not Available";
			Console.WriteLine($"Book Name is {title} and it is {available}");
		}
	}
}
