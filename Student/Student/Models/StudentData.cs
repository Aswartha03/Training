using System;

class StudentD
{
	List<Student> students = new List<Student>();

	public void AddStudent()
	{
		Console.Write("Enter The Student Name : ");
		string studentName = Console.ReadLine();

		Console.Write("Enter The Student Id : ");
		int studentId = Convert.ToInt32(Console.ReadLine());

		Student student = new Student(studentName, studentId);
		students.Add(student);

		Console.WriteLine("Student Added Successfully.");
	}

	public void DisplayStudents()
	{
		Console.WriteLine("Students List : ");

		if (students.Count == 0)
		{
			Console.WriteLine("No Data Found...");
			return;
		}

		foreach (Student student in students)
		{
			student.GetDetails();
		}

	}

	public void DeleteStudentById()
	{
		Console.WriteLine("Enter the Student Id : ");
		int studentId = Convert.ToInt32(Console.ReadLine());

		Student studentToDelete = students.FirstOrDefault(s => s.Id == studentId);
		// single or Default
		if (studentToDelete == null)
		{
			Console.WriteLine("Student Not Found");
			return;
		}

		students.Remove(studentToDelete);

		Console.WriteLine("Student is Deleted.");
	}


	public void SearchStudentById()
	{
		Console.WriteLine("Enter the Student Id : ");
		int studentId = Convert.ToInt32(Console.ReadLine());

		Student student = students.FirstOrDefault(s => s.Id == studentId);

		if (student == null)
		{
			Console.WriteLine("Student Not Found");
			return;
		}

		student.GetDetails();
	}

	public bool UpdateStudentById()
	{
		Console.WriteLine("Enter the Student Id : ");
		int studentId = Convert.ToInt32(Console.ReadLine());
		Student student = students.FirstOrDefault(s => s.Id == studentId);

		if (student == null)
		{
			Console.WriteLine("Student Not Found");
			return false;
		}
		Console.Write("Enter The Name to Update :");
		string updatedName = Console.ReadLine();
		if (updatedName=="")
		{
			Console.WriteLine("Enter the Valid Name");
			return false;
		}
		student.Name = updatedName;
		Console.WriteLine("Student Updated.");
		return true;
	}

}
