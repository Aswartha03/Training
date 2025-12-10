using System;


namespace ISP
{
	public class Program
	{
		//interface IWorker
		//{
		//	void Work();
		//	void Eat();
		//}

		//class Robot : IWorker
		//{
		//	public void Work()
		//	{
		//		Console.WriteLine("Working With 2X Speed");
		//	}
		//	public void Eat()
		//	{
		//		// Can't Eat . Robot class not required this method . but it is forced to be execute.
		//	}
		//}

		interface IWork()
		{
			void Work();
		}


		interface IEat()
		{
			void Eat();
		}

		class Robot : IWork
		{
			public void Work()
			{
				Console.WriteLine("Working With 2x Speed");
			}
		}

		class Human : IWork, IEat
		{
			public void Work()
			{
				Console.WriteLine("Working With Normal Speed");
			}
			public void Eat()
			{
				Console.WriteLine("Eating....")
			}

		}
		static public void Main()
		{

		}
	}
}
