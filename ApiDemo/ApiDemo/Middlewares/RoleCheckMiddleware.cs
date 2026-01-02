using System.Security.Claims;
using ApiDemo.Core.Models.ResponseModels;
namespace ApiDemo.Middlewares
{
    public class RoleCheckMiddleware
    {
        private readonly RequestDelegate next;
        public RoleCheckMiddleware(RequestDelegate nextProcess)
        {
            next = nextProcess;
        }
        public async Task InvokeAsync(HttpContext context) {
        
			if (context.Request.Path.StartsWithSegments("/student/edit-student"))
            {				
				if (!context.User.Identity?.IsAuthenticated??true)
                {           
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";
                    var response = new ApiResponse<Object>
                    {
                        Message = "Un Authorized , Please Login",
                        Data = null
                    };
                    await context.Response.WriteAsJsonAsync(response);
                    return ;
                }
                
                var role = context.User.FindFirst(ClaimTypes.Role)?.Value;

                if  (string.IsNullOrEmpty(role) || role.ToLower() != "admin")
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    context.Response.ContentType = "application/json";
                    var response = new ApiResponse<Object>
                    {
                        Message = "Forbidden , Admin Role is Required",
                        Data = null
                    };
                    await context.Response.WriteAsJsonAsync(response); 
                    return;
                }
            }
            await next(context);
        }
    }
}
