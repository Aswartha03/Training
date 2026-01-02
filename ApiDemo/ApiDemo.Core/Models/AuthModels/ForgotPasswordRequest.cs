using System.ComponentModel.DataAnnotations;

namespace ApiDemo.Core.Models.AuthModels
{
    public class ForgotPasswordRequest
    {
        [Required(ErrorMessage ="Email Required to Reset The Password")]
        [EmailAddress]
       public string Email { get; set; }
    }
}
