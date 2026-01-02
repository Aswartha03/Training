using System.ComponentModel.DataAnnotations;

namespace ApiDemo.Core.Models.AuthModels
{
    public class Register
    { 
        [Required(ErrorMessage = "Name is Required")]  
		public  string Username { get; set; } 

        [EmailAddress]  
        [Required(ErrorMessage = "Email Required")]
        //[RegularExpression("^()$" , ErrorMessage ="Invalid Email, Must have @gmail.com")]
        public string Email { get; set; } 

		[Required] 
        // Structure of password 
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
		public  string Password { get; set; }

        [RegularExpression("^(student|user|admin)$",ErrorMessage = " Invalid Role , Role Must be a student , user or admin")]
        public string? Role { get; set; } = "student";

        //[Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")] 
        //[MaxLength(3, ErrorMessage = "Age cannot exceed 3 digits.")] 
        
	}
}
