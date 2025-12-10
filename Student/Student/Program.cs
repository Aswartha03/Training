namespace Student_Management
{
    internal class Program
    {
       // DTO 
	   // VIew Model
	   // out 
	   class Student
		{
			public string Name;
			public Marks MarksDetails;
		}

		class Marks
		{
			public int Score;
		}
        static void Main(string[] args)
        {


			Student s1 = new Student();
			s1.Name = "Sudheer";
			s1.MarksDetails = new Marks();
			s1.MarksDetails.Score = 90;  // creation
			Console.WriteLine(s1.Name); 


			Student s2 = (Student)s1.MemberWiseClone();
			s2.Name = "Ajay";
			s2.MarksDetails.Score = 80;

			Console.WriteLine();
   //         int choice;
   //         StudentD studentLibrary = new StudentD();

   //         Console.WriteLine("Student Management App...");

			//Console.WriteLine("1. Add Student");
			//Console.WriteLine("2. Search Student");
			//Console.WriteLine("3. Delete Student");
			//Console.WriteLine("4. Display Students");
			//Console.WriteLine("5. Update Student");
			//Console.WriteLine("6. Exit"); 

			//do
   //         {
			//	Console.Write("Enter Your Choice : ");
			//	choice = Convert.ToInt32(Console.ReadLine());

			//	switch (choice)
			//	{
			//		case 1:
			//			studentLibrary.AddStudent();
			//			break;

			//		case 2:
			//			studentLibrary.SearchStudentById();
			//			break;

			//		case 3:
			//			studentLibrary.DeleteStudentById();
			//			break;

			//		case 4:
			//			studentLibrary.DisplayStudents();
			//			break;

			//		case 5:
			//			studentLibrary.UpdateStudentById();
			//			break;

			//		case 6:
			//			Console.WriteLine("Exiting The Program...");
			//			break;
					
			//		default:
			//			Console.WriteLine("Invalid Case");
			//			break;
			//	}
			//} while (choice != 6);
           
        }
    }
}
