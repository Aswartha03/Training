using System;

namespace SRP
{
	class Program
	{
		//class Employee()
		//{
		//	public string Name;
		//	public int Age ;
		//	public Employee(string sName, int sAge)
		//	{
		//		Name = sName;
		//		Age = sAge;
		//	}

		//	public void Save()
		//	{
		//		Console.WriteLine("Saving The Employee");
		//	}
		//	public void GenerateReport()
		//	{
		//		Console.WriteLine("Generating The Report");
		//	}
		//}   
		class Employee
		{
			public string Name;
			public int Age;
			public Employee(string sName, int sAge)
			{
				Name = sName;
				Age = sAge;
			}

			public void Save()
			{
				Console.WriteLine("Saving The Employee");
			}
		}

		class Report
		{
			public void Generate()
			{
				Console.WriteLine("Generating The Report");
			}
		}

		static public void Main()
		{

		}
	}
}
