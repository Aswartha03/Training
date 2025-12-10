using System;

namespace InOutRef
{
	class Program
	{
		// In Example
		//Use Cases : Read-only parameters
						// Do not modify the value of the parameter inside the method

		public void IncrementNumber(in int number)
		{
			number++; // This will cause a compile-time error 
					  // Can't Modify 'in' parameter 
		}

		// Out Example 
		// Use Cases : When a method needs to return multiple values
						// We must assign a value to an out parameter before the method returns


		public void GetValues(out int age , out string name)
		{
			age = 38;
			name = "Rohit Sharma";
		}


		// Ref Example
		//Use Cases :  // When you want to pass a variable by reference and allow the method to modify its value
						// We must initialize a ref parameter before passing it to the method

		public void UpdateName(ref string username)

		{ 
			username = "UpdatedName";
		}


		static public void Main(string[] args)
		{
			// In Example :
			int number = 5;
			Console.WriteLine("Before Increment: " + number);
			IncrementNumber(in number);
			Console.WriteLine("After Increment using In: " + number);

			// Out Example :
			int age;
			string name;
			GetValues(out age , out name);
			Console.WriteLine("Name: " + name + ", Age: " + age);


			// Ref Example :

			string username = "OriginalName";
			Console.WriteLine("Before Update: " + username);
			UpdateName(ref username);
			Console.WriteLine("After Update using Ref: " + username);

		}

	}
}
