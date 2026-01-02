using System.ComponentModel.DataAnnotations;

namespace ApiDemo.Core.Models.AuthModels
{
    public class ResetPasswordRequest
    {
        [Required(ErrorMessage ="Password Required to Reset")]
		[MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
		public string Password { get; set; }
    }
}
