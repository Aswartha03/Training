using ApiDemo.Core.Models.AuthModels;
using ApiDemo.Core.Models.ResponseModels;
using ApiDemo.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
	
	[ApiController] 
	[Route("auth")] 
    public class AuthController : ControllerBase
    {

		// storing the Register students
		// DI 
		private readonly AuthService authService;

		public AuthController(AuthService service)
		{
			authService = service;
		} 

		// register student endpoint
		[HttpPost("register")]
		public IActionResult RegisterStudent([FromBody] Register register)
		{
			var response  = authService.Register(register);

			return Created("", response);
		}

		// login endpoint 

		[HttpPost("login")] 
		// What if , we not keep the frombody 
		public IActionResult LoginUser(Login login)
		{ 
			// We will get Email and password from the body 
			// this keyword will help us to bind the data from body to login object
			// get request - body passing.
			var response = authService.Login(login);
			if(response.Data == null)
			{
				if(response.Message== "Password Wrong.") { return Unauthorized(response); }
				else return BadRequest(response);
			} 
			return Ok(response); 
		}

		[HttpPost("forgot-password")]
		public IActionResult ForgotPassword( ForgotPasswordRequest request)
		{
			// Will get email from request body
			var response = authService.ForgotPasswordReset(request.Email);
			if(response.Message == "User Not Found") { return NotFound(response); }
			else
			{
				return Ok(new ApiResponse<Object>
				{
					Message = "Reset Password Link is Shared and it will valid only for 10 minutes",
					Data = response.Message
				});
			}
			 
		}

		[HttpPost("reset-password/{id}")]
		public IActionResult ResetPassword(int id, ResetPasswordRequest request)
		{
			// will get id from params and password from request body
			var response = authService.ResetPassword(id, request.Password);
			if (response.Message == "User Not Found") { return NotFound(response); }
			else return Ok(new ApiResponse<Object>
			{
				Message = response.Message, 
				Data = null
			});
		}
	}
}
