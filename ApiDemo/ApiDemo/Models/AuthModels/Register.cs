using System.ComponentModel.DataAnnotations;

namespace ApiDemo.Models.AuthModels
{
    public class Register
    { 
        [Required] 
		public  string Name { get; set; }

        [EmailAddress]  [Required] public string Username { get; set; }


		[Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
		public  string Password { get; set; }
        
	}
}
