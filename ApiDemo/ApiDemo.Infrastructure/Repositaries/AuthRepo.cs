using ApiDemo.Core.Entities;
using ApiDemo.Core.Interfaces;
using ApiDemo.Core.Models.AuthModels;
using ApiDemo.Core.Models.ResponseModels;
using ApiDemo.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using PetaPoco; 

namespace ApiDemo.Infrastructure.Repositaries
{
    public class AuthRepo : IAuthRepo
    {
		private readonly Database db;
		public AuthRepo(Database database)
		{
			db = database;
		} 
		public ApiResponse<Object> RegisterUser(Register register)
        {
			
			User? isUserAlreadyRegister = db.FirstOrDefault<User>("SELECT * FROM Users WHERE EMAIL = @0", register.Email);
			// User is not registered
			if (isUserAlreadyRegister == null) {
				// Hashing the Password 
				var passwordHasher = new PasswordHasher<Register>();
				register.Password = passwordHasher.HashPassword(register, register.Password);
				// Inserting the new user
				db.Insert("Users", "UserId", true, register);
				return new ApiResponse<Object>
				{
					Message = "User Registered Successfully",
					Data = new {
						EmailId = register.Email,
						Name = register.Username 
					} 
				};
			}
			return new ApiResponse<Object>
			{
				Message = "User Already Registered, Please Login",
				Data = null
			};
        } 

		public ApiResponse<Object> LoginUser(Login login) 
        {
			User? user = db.FirstOrDefault<User>("SELECT * FROM Users WHERE Email = @0", login.Email);
			if (user == null) {
				return new ApiResponse<Object>
				{
					Message = "Invalid Email , Please Register",
					Data = null 
				};
			}
			// Verifing the stored hashed password and entered password
			var passwordHasher = new PasswordHasher<User>();
			var result = passwordHasher.VerifyHashedPassword(user, user.Password, login.Password);
			// if password is macthed
			if (result == PasswordVerificationResult.Success)
			{
				// creating the jwt token
				var token = JwtService.GenerateToken(user);
				return new ApiResponse<Object>
				{
					Message = "Login Successful , token expires in 60 minutes",
					Data = new { Token = token }
				};
			}
			// if password is wrong
			return new ApiResponse<Object>
			{
				Message = "Password Wrong.",
				Data = null
			};
		}

		public string ForgotPassword(string email)
		{
			User? user =  db.FirstOrDefault<User>("SELECT * FROM Users WHERE Email = @0", email);
			if (user == null) {
				return "User Not Found";
			}
			//var token = JwtService.GenerateToken(user);
			// I need to generate one jwt token but just for practice i directly giving the link
			return $"https://localhost:7242/auth/reset-password/{user.UserId}";
		}

		public string ResetPassword(int id, string newPassword)
		{
			User? user = db.FirstOrDefault<User>("SELECT * FROM Users WHERE UserId = @0", id);
			var passwordHasher = new PasswordHasher<User>();
			string hashedPassword = passwordHasher.HashPassword(user, newPassword);
			var affected = db.Execute(
				"UPDATE Users SET Password = @0 WHERE UserId = @1",
				hashedPassword,
				id
			);
			return affected == 0 ? "User Not Found" : "Password Updated Successfully";
		}

    }
}
