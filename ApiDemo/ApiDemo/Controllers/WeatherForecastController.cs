using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [ApiController] // Attributes
    [Route("[controller]")]  
    public class WeatherForecastController : ControllerBase 
    {
        // get , post -> Retriving Data Difference 
        // API , REST API  , GraphQL , Sockets
        // FROM Body , From Query , Custom Attribute 
        // in out ref
        //  a new end point will have : http Method , pathname , code to execute
        private static  string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        // store the students 
        public static List<Student> students = new List<Student>();


        [HttpGet(Name = "GetWeatherForecast")]
        
        public IEnumerable<WeatherForecast> Get() 
        {
            //return "";
            //WeatherForecastController.
            //return [1, 2, 3, 4];
            return Enumerable.Range(1, 4).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            }) 
            .ToArray();
        }

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

        [HttpGet("students")]
       
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

        [HttpPatch("edit-student/{id}")]  // edit student by id
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
    }
}
