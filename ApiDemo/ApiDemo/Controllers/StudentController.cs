using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [ApiController] // Attributes 
    [Route("student")]
    public class StudentController : ControllerBase
    {

        //  a new end point will have : http Method , pathname , code to execute

        // store the students 
        public static List<Student> students = new List<Student>();
        // storing the Register students
        public static List<Login> loginStudents = new List<Login>();


		// register student endpoint
		[HttpPost("register")]
        public IActionResult RegisterStudent([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.Username))
            {
                return BadRequest(new ApiResponse<Login>
                {
                    Message = "Username is Required",
                    Data = null
                });
            }
            if (string.IsNullOrWhiteSpace(login.Password))
            {
                return BadRequest(new ApiResponse<Login>
                {
                    Message = "Password is Required",
                    Data = null
                });
            }
            if(string.IsNullOrWhiteSpace(login.Name))
            {
                return BadRequest(new ApiResponse<Login>
                {
                    Message = "Name is Required",
                    Data = null
                });
			}

			loginStudents.Add(login);

            return Created("", new ApiResponse<Login>
            {
                Message = "User Registered Successfully",
                Data = login
            });
		}

		// login endpoint

		[HttpPost("login")]

        public IActionResult LoginStudent([FromBody] Login login)
        {
			// We will get username and password from the body 

			if (string.IsNullOrWhiteSpace(login.Username))
            {
                return BadRequest(new ApiResponse<Login>
                {
                    Message = "Username is Required",
                    Data = null
                });
            }
            if (string.IsNullOrWhiteSpace(login.Password))
            {
                return BadRequest(new ApiResponse<Login>
                {
                    Message = "Password is Required",
                    Data = null
                });
            }

            Login studentExist = loginStudents.FirstOrDefault(student => student.Username == login.Username && student.Password == login.Password);
            //Console.WriteLine(studentExist);
            if (studentExist == null)
            {
                return NotFound(new ApiResponse<Login>
                {
                    Message = "Invalid Username or Password",
                    Data = null
                });
            }
            return "Hello";
            //return Ok(studentExist);
		}

		[HttpPost("add-student")] // post request to add the student
        public IActionResult AddStudent([FromBody] Student student)
        {

            if (string.IsNullOrWhiteSpace(student.Name))
            {
                return BadRequest(new ApiResponse<Student>
                {
                    Message = "Name is Required",
                    Data = null
                });
            }

            if (student.Age <= 0)
            {
                return BadRequest(new ApiResponse<Student>
                {
                    Message = "Age Must be Positive",
                    Data = null 
                });
            }

            // find and setting  the id manually 
            int currentId = students.Count() > 0 ? students[students.Count()-1].studentId : 0;
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

            if (students.Count == 0)
            {
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
        public IActionResult EditStudentById(int id, [FromBody] Student student)
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
            if (isExist == false)
            {
                // student not found
                return NotFound(new ApiResponse<Student>
                {
                    Message = $"No Student Exist With The Id : {id} To Update",
                    Data = null
                });
            }

            Student studentExist = students.First(s => s.studentId == id);

            if (string.IsNullOrWhiteSpace(student.Name) == false)
            {
                studentExist.Name = student.Name;
            }

            if (student.Age > 0)
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
                return BadRequest(new ApiResponse<Student>
                {
                    Message = "Id Is Required",
                    Data = null
                });
            }
            // id is negative or zero   
            if (id <= 0)
            {
                return BadRequest(new ApiResponse<Student>
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
            if (student == null)
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

        [HttpDelete("delete-student/{id}")] // delete student by id from url    

        public IActionResult DeleteStudentById(int id)
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

            Student student = students.FirstOrDefault(stu => stu.studentId == id);

            if (student == null)
            {
                // student not found
                return NotFound(new ApiResponse<Student>
                {
                    Message = $"No Student Exist With The Id : {id} To Delete",
                    Data = null
                }); 
            }

            students.Remove(student);

            return Ok(new ApiResponse<Student>
            {
                Message = "Student Deleted Succesfully",
                Data = student
            });
        }
    }
}
