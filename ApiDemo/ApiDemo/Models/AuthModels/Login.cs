using System;
using System.ComponentModel.DataAnnotations;

namespace ApiDemo.Models.AuthModels
{
	public class Login
	{
		[Required]
		public required string Username { get; set; }

		[Required]
		[MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
		public required string Password { get; set; }
}
}
