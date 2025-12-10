using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int result = 0;
        static void Add()
        {
            Console.Write("Enter Value to add : ");
            int a = Convert.ToInt32(Console.ReadLine());
            result += a;
            Console.WriteLine("Added Successfully");
        } 
        static void Sub()
        {
			Console.Write("Enter Value to Substract : ");
			int a = Convert.ToInt32(Console.ReadLine());
			result -= a;
            Console.WriteLine("Substracted Succesfully");
        }
        static void Mul()
        {
			Console.Write("Enter Value to Multiply : ");
			int a = Convert.ToInt32(Console.ReadLine());
			result *= a;
            Console.WriteLine("Multiplied Succesfully");
        }
        static void Div()
        {
			Console.Write("Enter Value to Divide : ");
			int a = Convert.ToInt32(Console.ReadLine());
			result /= a;
            Console.WriteLine("Divided Succesfully");
        }
        static void Result()
        {
            Console.WriteLine($"Current Value : {result}");
        }
        static void Main(string[] args)
        {
            int choice;
            do
            {
				Console.WriteLine("Arithmetic Console App...");

				Console.WriteLine("1. Add");
				Console.WriteLine("2. Substract");
				Console.WriteLine("3. Multiply");
				Console.WriteLine("4. Divide");
                Console.WriteLine("5. CheckValue");
                Console.WriteLine("6. Exit");

				Console.Write("Select Your Choice : ");

                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Add();
                        break;

                    case 2: 
                        Sub(); 
                        break;
                        
                    case 3: 
                        Mul();
                        break;
                       
                    case 4:
                        Div(); 
                        break;

                    case 5:
                        Result();
                        break;

                    case 6:
                        Console.WriteLine("Exiting The Program");
                        break;

                    default:
                        Console.WriteLine("Invalid Case.");
                        break;
                }
			} while (choice != 6);
            
        }
    }
}
