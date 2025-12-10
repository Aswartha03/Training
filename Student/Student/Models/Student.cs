using System;

public class Student
{
	/// <summary>
	/// 
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// 
	/// </summary>
	public int Id { get; private set; }
	// GuId
	// architecture
	// extention generation
	// sealed 
	public Student(string studentName, int studentId)
	{
		Name = studentName;
		Id = studentId;
	}

	public void GetDetails()
	{
		Console.WriteLine($"Student Name is :{Name} and id is : {Id}");
	}
	
}
