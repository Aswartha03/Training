//using System;

//delegate void MyDelegete();
//delegate void Message(string name);
////To pass a method as a parameter

////For callback functions

////To trigger events

//namespace HelloWorld
//{
//	public class Program 
//	{
//		static void SayHello()
//		{
//			Console.WriteLine("Hello World!");
//		}
//		static void Greet(string name)
//		{
//			Console.WriteLine($"Hello : {name}");
//		}
//		public static void Main(string[] args)
//		{

//			MyDelegete d = SayHello;
//			d();
//			Message g = Greet;
//			g("Aswartha");
//			// List<int> numbers = new List<int>();
//			// numbers.Add(2);
//			// numbers.Add(4);
//			// numbers.Add(6);
//			// foreach(int i in numbers){
//			//   Console.WriteLine(i);
//			// }
//			// Dictionary<int,string> users = new Dictionary<int,string>();
//			// users.Add(101,"Bharat");
//			// users.Add(102,"Jaggu");
//			// users.Add(103,"Lokesh");

//			// foreach(var user in users){
//			//   Console.WriteLine($"{user.Key} -> {user.Value}");
//			// }
//			// Console.WriteLine(users[101]);
//			// if(users.ContainsKey(101)){
//			//   Console.WriteLine("Value Find");
//			// }else{
//			//   Console.WriteLine("Not Found");
//			// }

//			// try{
//			//   int a = 20;
//			//   int b = 10;
//			//   int result = a/b;
//			//   Console.WriteLine("Result : "+ result);
//			//   Console.WriteLine(users[104]);
//			// }catch(Exception error){
//			//   Console.WriteLine("Error : " + error.Message);
//			// }finally{
//			//   Console.WriteLine("Code Ended.");
//			// }
//		}
//	}
//}