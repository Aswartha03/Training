using ApiDemo.Models.StudentModels;
using ApiDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [ApiController] // Attributes 
    [Route("student")]
    public class StudentController : ControllerBase
    {

        //  a new end point will have : http Method , pathname , code to execute

        // store the students 

        private readonly StudentService _studentService;
        public StudentController(StudentService service)
        {
            _studentService = service;
        }



		[HttpPost("add-student")] // post request to add the student
        public IActionResult AddStudent([FromBody] Student student)
        {
            var response = _studentService.AddStudent(student);
            return Created("", response);
		}

        [HttpGet("get-students")] // get all students

        public IActionResult DisplayStudents()
        {

            var response = _studentService.GetAllStudents();
            if ((response.Data==null))
            {
                return NotFound(response);
            }
            return Ok(response);

		}

        [HttpPatch("edit-student/{id}")]  // edit student by id by URl
        public IActionResult EditStudentById(int id, [FromBody] Student student)
        {
            var response = _studentService.UpdateStudentById(id, student);
            if (response.Data == null) { 
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("get-student")] // get student by query param

        public IActionResult GetStudentById([FromQuery] int id)
        {

           var response = _studentService.GetStudentById(id);
        if(response.Message == "Student Not Found")
            {
                return NotFound(response);
            }
            if (response.Data == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
            

        }

        [HttpDelete("delete-student/{id}")] // delete student by id from url    

        public IActionResult DeleteStudentById(int id)
        {

            var response = _studentService.DeleteStudentById(id);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
