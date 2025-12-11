using ApiDemo.Models.AuthModels;
using ApiDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
	
	[ApiController]
	[Route("auth")] 
    public class AuthController : ControllerBase
    {

		// storing the Register students
		AuthService authService = new AuthService();
	
		// register student endpoint
		[HttpPost("register")]
		public IActionResult RegisterStudent([FromBody] Register register)
		{
			var response  = authService.RegisterStudent(register);

			return Created("", response);
		}

		// login endpoint

		[HttpPost("login")]

		public IActionResult LoginStudent([FromBody] Login login)
		{
			// We will get username and password from the body 
			var responce = authService.LoginStudent(login);
			if(responce.Data == null)
			{
				return BadRequest(responce);
			}
			return Ok(responce);
			
		}
	}
}
