using System;

namespace LSP
{
	class Program
	{
		class Bird
		{
			public void Fly()
			{
				Console.WriteLine("Bird Is Flying");
			}
		}

		//class Ostrich : Bird
		//{
		//	public void Fly()
		//	{
		//		Console.WriteLine("Ostrich Can't Fly"); // prevents the LSP .
		//	}
		//}

		interface IEat
		{
			void Eat();
		}


		class Swallow : Bird , IEat
		{
			public void Eat()
			{
				Console.WriteLine("Swallow Eating....");
			}
		}

		class Ostrich : Bird { }

		static public void Main()
		{
			Ostrich ostrich = new Ostrich();
			ostrich.Fly();

			Swallow swallow = new Swallow();
			swallow.Fly();
			swallow.Eat();
		}
	}
}
