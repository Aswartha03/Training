using ApiDemo.Models.AuthModels;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Services
{
    public class AuthService  
    {
		public static List<Register> loginStudents = new List<Register>();

		public ApiResponse<Register> RegisterStudent(Register register)
		{
			loginStudents.Add(register);
			return new ApiResponse<Register>
			{
				Message = "User Registered Successfully",
				Data = register
			};
		}

		public ApiResponse<Register> LoginStudent(Login login)
		{
			Register? studentExist = loginStudents.FirstOrDefault(student => student.Username == login.Username && student.Password == login.Password);

			if (studentExist == null)
			{
				return new ApiResponse<Register>
				{
					Message = "Invalid Username or Password",
					Data = null
				};
			}
			return new ApiResponse<Register>
			{
				Message = "Login Successful",
				Data = studentExist
			};
		}
	}
}
