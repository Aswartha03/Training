using ApiDemo.Core.Interfaces;
using ApiDemo.Core.Models.AuthModels;
using ApiDemo.Core.Models.ResponseModels;
using Microsoft.AspNetCore.Identity;

namespace ApiDemo.Infrastructure.Services
{
    public class AuthService  
    {
		private readonly IAuthRepo authRepo;
		public AuthService(IAuthRepo authRepository)
		{
			authRepo = authRepository;
		}

		public ApiResponse<Object> Register(Register register)
		{ 
			var response = authRepo.RegisterUser(register);
			return new ApiResponse<Object> 
			{
				Message = response.Message,
				Data = response.Data 
			};
		} 

		public ApiResponse<Object> Login(Login login)
		{
			var response = authRepo.LoginUser(login);
			return new ApiResponse<Object>
			{
				Message = response.Message,
				Data = response.Data
			};
		}

		public ApiResponse<Object> ForgotPasswordReset(string email) {
			string response = authRepo.ForgotPassword(email);
			return new ApiResponse<Object>
			{
				Message = response,
				Data = null 
			};
		}

		public ApiResponse<Object> ResetPassword(int id, string password) { 
			string response = authRepo.ResetPassword(id, password);
			return new ApiResponse<object>
			{
				Message = response,
				Data = null
			};
		}
	}
}
