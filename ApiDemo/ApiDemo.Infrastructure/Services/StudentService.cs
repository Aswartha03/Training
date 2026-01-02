using ApiDemo.Core.Entities;
using ApiDemo.Core.Interfaces;
using ApiDemo.Core.Models.ResponseModels;
using ApiDemo.Core.Models.StudentModels;

namespace ApiDemo.Infrastructure.Services
{
	// interface creation 
    public class StudentService 
    {
		public readonly IStudentRepo studentRepo;
		public StudentService(IStudentRepo studentRepository)
		{
			studentRepo = studentRepository; 
		}

		// helper functions start here
		public ApiResponse<List<StudentEntity>> NotFoundResponseMultiple(string message)
		{
				return new ApiResponse<List<StudentEntity>>
				{
					Message = message,
					Data = null 
				};
		}

		public ApiResponse<StudentEntity> NotFoundResponseSingle(string message)
		{
			return new ApiResponse<StudentEntity>
			{
				Message = message,
				Data = null
			};
		}
		public ApiResponse<StudentEntity> IdIsNotPresentResponce(string message)
		{ 
			return (new ApiResponse<StudentEntity>	
			{
				Message = message,
				Data = null
			});
			
		}

		public ApiResponse<StudentEntity> NegativeIdResponse(string message)
		{
			return new ApiResponse<StudentEntity>
			{
				Message = message,
				Data = null
			};
		}
		
		// helper functions end here

		public ApiResponse<List<StudentEntity>> GetAllStudents()

        {
			List<StudentEntity> students = studentRepo.GetAll();
           if(students.Count == 0) 
			{
				return NotFoundResponseMultiple("No Students Found");
			}

			return new ApiResponse<List<StudentEntity>>
			{
				Message = "Students retrieved successfully",
				Data = students
			};
		}
		
        public ApiResponse<StudentEntity>  GetStudentById(int id)
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
			StudentEntity? student = studentRepo.GetStudentById(id);
			if (student == null)
			{
				return NotFoundResponseSingle("Student Not Found");
			}
			// successfull retrive operation

			return new ApiResponse<StudentEntity>
			{
				Message = "Student Fetched Successfully",
				Data = student
			};

		}

		// Naming Convetions 
		public ApiResponse<StudentEntity> DeleteStudentById(int id)
		{
			List<StudentEntity> students = studentRepo.GetAll();
			if (students.Count==0)
			{
				return NotFoundResponseSingle("No Students Found");
			}

			StudentEntity? student = studentRepo.GetStudentById(id);

			if (student == null)
			{
				return NotFoundResponseSingle($"No Student Exist With The Id : {id} To Delete");
			}else
			{
				studentRepo.DeleteStudent(id);
				return (new ApiResponse<StudentEntity>
				{
					Message = "Student Deleted Succesfully",
					Data = student
				});
			}
				
		}

		public ApiResponse<StudentEntity> UpdateStudentById(int id, Student student)
		{
			List<StudentEntity> students = studentRepo.GetAll();
			if (students.Count == 0)
			{
				return NotFoundResponseSingle("No Students Found");
			}

			StudentEntity? studentExist = studentRepo.GetStudentById(id);

			if (studentExist == null)
			{
				return NotFoundResponseSingle($"No Student Exist With The Id : {id} To Update");
			}

			StudentEntity updatedStudent = studentRepo.UpdateStudent(studentExist, student);
			// success full updation
			return (new ApiResponse<StudentEntity>
			{
				Message = "Student Updated Succesfully",
				Data = updatedStudent 
			});

		}


		public ApiResponse<Student> AddStudent(Student student) {

			Student newStudent = studentRepo.AddStudent(student);
			// succesfully added
			return (new ApiResponse<Student>
			{
				Message = "Student Added Successfully",
				Data = newStudent
			});

		}
	}
}
