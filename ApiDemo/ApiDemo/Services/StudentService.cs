using ApiDemo.Models.StudentModels;

namespace ApiDemo.Services
{
	
    public class StudentService
    {
        public readonly List<Student> _students = new List<Student>();


		// helper functions start here
		public ApiResponse<List<Student>> NotFoundResponseMultiple(string message)
		{
				return new ApiResponse<List<Student>>
				{
					Message = message,
					Data = null
				}; 
		}

		public ApiResponse<Student> NotFoundResponseSingle(string message)
		{
			return new ApiResponse<Student>
			{
				Message = message,
				Data = null
			};
		}
		public ApiResponse<Student> IdIsNotPresentResponce(string message)
		{ 
			
			return (new ApiResponse<Student>
			{
				Message = message,
				Data = null
			});
			
		}

		public ApiResponse<Student> NegativeIdResponse(string message)
		{
			return new ApiResponse<Student>
			{
				Message = message,
				Data = null 
			};
		}
		
		public Student?  RetriveStudentWithId(int id)
		{
			Student? student = _students.FirstOrDefault(student => student.studentId == id);
			return student;
		}
		// helper functions end here

		public ApiResponse<List<Student>> GetAllStudents()

        {
           if(_students.Count == 0)
			{
				return NotFoundResponseMultiple("Not Students Found");
			}

			return new ApiResponse<List<Student>>
			{
				Message = "Students retrieved successfully",
				Data = _students
			};
		}
		
        public ApiResponse<Student>  GetStudentById(int id)
        {
			if (string.IsNullOrWhiteSpace(id.ToString()))
			{
				return IdIsNotPresentResponce("Id Is Required");
			}
			if (id <= 0)
			{
				return NegativeIdResponse("Id Must Be A Positive Number");
			}
			
			// Checking whether student is exist or not with given id
			Student? student = RetriveStudentWithId(id);
			if (student == null)
			{
				return NotFoundResponseSingle("Student Not Found");
			}
			// successfull retrive operation

			return new ApiResponse<Student>
			{
				Message = "Student Fetched Successfully",
				Data = student
			};

		}


		public ApiResponse<Student> DeleteStudentById(int id)
		{
			if (_students.Count==0)
			{
				return NotFoundResponseSingle("No Students Found");
			}

			Student? student = RetriveStudentWithId(id);

			if (student == null)
			{
				return NotFoundResponseSingle($"No Student Exist With The Id : {id} To Delete");
			}else
			{
				_students.Remove(student);

				return (new ApiResponse<Student>
				{
					Message = "Student Deleted Succesfully",
					Data = student
				});
			}
				
		}

        
		public ApiResponse<Student> UpdateStudentById(int id, Student student)
		{
			if (_students.Count == 0)
			{
				return NotFoundResponseSingle("No Students Found");
			}

			Student? studentExist = RetriveStudentWithId(id);

			if (studentExist == null)
			{
				return NotFoundResponseSingle($"No Student Exist With The Id : {id} To Update");
			}

				if (string.IsNullOrWhiteSpace(student.Name) == false)
			{
				studentExist.Name = student.Name;
			}

			if (student.Age > 0)
			{
				studentExist.Age = student.Age;
			}
			// success full updation
			return (new ApiResponse<Student>
			{
				Message = "Student Updated Succesfully",
				Data = studentExist
			});

		}


		public ApiResponse<Student> AddStudent(Student student) {

			// find current id
			int currentId = _students.Count() > 0 ? _students[_students.Count - 1].studentId : 0;
			student.studentId = currentId + 1;
			_students.Add(student);

			// succesfully added
			return (new ApiResponse<Student>
			{
				Message = "Student Added Successfully",
				Data = student
			});

		}
	}
}
