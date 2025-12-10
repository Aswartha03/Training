using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [ApiController] // Attributes
    [Route("student")]   
    public class StudentController : ControllerBase 
    {

        //  a new end point will have : http Method , pathname , code to execute

        [HttpGet("Hello")] // Testing Route

        public string Hello()
        {
            return "Hello from Student API"; 
		}
		// store the students 
		public static List<Student> students = new List<Student>();


        [HttpPost("add-student")] // post request to add the student
        public IActionResult AddStudent([FromBody] Student student)
        {

            if(string.IsNullOrWhiteSpace(student.Name))
            {
                return BadRequest(new ApiResponse<Student>
                {
                    Message = "Name is Required",
                    Data = null
                });
            }

            if(student.Age <= 0)
            {
                return BadRequest(new ApiResponse<Student>
                {
                    Message = "Age Must be Positive",
                    Data = null
                });
            }
            // find and setting  the id manually 
            int currentId = students.Count() > 0 ? students.Count() : 0;
            student.studentId = currentId + 1;
            students.Add(student);
            // succesfully added
            return Created("", new ApiResponse<Student>
            {
                Message = "Student Added Successfully",
                Data = student
            });

        }

        [HttpGet("get-students")] // get all students

		public IActionResult DisplayStudents()
        {

            if (students.Count == 0) {
                // data not found
                return NotFound(new ApiResponse<List<Student>>
                {
                    Message = "No Students Found",
                    Data = null
                });
            }
            // successfull retrive operations
            return Ok(new ApiResponse<List<Student>>
			{
				Message = "Students Fetched Succesfully",
				Data = students
			});
        }

        [HttpPatch("edit-student/{id}")]  // edit student by id by URl
        public IActionResult EditStudentById(int id , [FromBody] Student student) 
        {
			if (students.Count == 0)
			{
				// data not found
				return NotFound(new ApiResponse<List<Student>>
				{
					Message = "No Students Found",
					Data = null
				});
			} 
            
			bool isExist = students.Any(stu => stu.studentId == id);
            if (isExist==false)
            {
				// student not found
				return NotFound(new ApiResponse<Student> 
                {
                    Message = $"No Student Exist With The Id : {id} To Update",
                    Data = null
                });
            }

            Student studentExist = students.First(s => s.studentId == id);

            if ( string.IsNullOrWhiteSpace(student.Name) == false)
            {
                studentExist.Name = student.Name;
            }

            if(student.Age > 0)
            {
                studentExist.Age = student.Age;
            }
            // success full updation
            return Ok(new ApiResponse<Student>
            {
                Message = "Student Updated Succesfully",
                Data = studentExist
            });

        }

        [HttpGet("get-student")] // get student by query param
                                 
        public IActionResult GetStudentById([FromQuery] int id)
        {
			// id is not provided
			if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest( new ApiResponse<Student>
                {
                    Message = "Id Is Required",
                    Data = null
                });
            }
			// id is negative or zero   
			if (id <= 0)
            {
                return BadRequest( new ApiResponse<Student>
                {
                    Message = "Id Must Be Positive",
                    Data = null
                });
            }

			// not found cases
			if (students.Count == 0)
            {
                // data not found
                return NotFound(new ApiResponse<List<Student>>
                {
                    Message = "No Students Found",
                    Data = null
                });
            }
            // Checking whether student is exist or not with given id
            Student student = students.FirstOrDefault(student => student.studentId == id); 
              if(student == null)
            {
                    return NotFound(new ApiResponse<Student>
                    {
                        Message = $"No Student Found With The Id : {id}",
                        Data = null
                    });
            }
			// successfull retrive operation

			return Ok(new ApiResponse<Student>
              {
                  Message = "Student Fetched Succesfully",
                  Data = student
              });

        }
	}
}
