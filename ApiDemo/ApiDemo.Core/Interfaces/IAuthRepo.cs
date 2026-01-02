using ApiDemo.Core.Entities;
using ApiDemo.Core.Models.AuthModels;
using ApiDemo.Core.Models.ResponseModels;

namespace ApiDemo.Core.Interfaces
{
    public interface IAuthRepo
    {
        public ApiResponse<Object> RegisterUser(Register register);
        public ApiResponse<Object> LoginUser(Login login);
        public string ForgotPassword(string email);
        public string ResetPassword(int id, string newPassword);
    } 
}
