using System.Text;
using ApiDemo.Core.Interfaces;
using ApiDemo.Middlewares;
using ApiDemo.Infrastructure.Repositaries;
using ApiDemo.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PetaPoco;
namespace ApiDemo
{ 
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			// Registers services (like controllers, Swagger, logging, etc.)
			builder.Services.AddControllers();
			// I want to use Controllers in my API. 
			builder.Services.AddOpenApi();
			// adds OpenAPI/Swagger support to your API 
			// add scoped -> if service using any user request data or db 
			// add singleton -> if service only for read-only data or logging purpose
			// Registering with DB
			builder.Services.AddScoped<Database>(serviceProvider =>
			{
				var config = serviceProvider.GetRequiredService<IConfiguration>();
				var connectionString = config.GetConnectionString("DefaultConnection");
				return new Database(connectionString,"Microsoft.Data.SqlClient");
			});

			builder.Services.AddScoped< IAuthRepo,AuthRepo>();
			builder.Services.AddScoped<AuthService>();
			builder.Services.AddScoped<IStudentRepo , StudentRepo>();
			builder.Services.AddScoped<StudentService>();
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true, // token expiry validation
					ValidateIssuerSigningKey = true, // signin key validation
					IssuerSigningKey = new SymmetricSecurityKey(
						Encoding.UTF8.GetBytes("8F2a9#XzPqL!9K@3R7mW$H4D1sB6ZQvC")
					),
				};
			});
			var app = builder.Build();
			// Construction completed. App is ready to run.” 
			if (app.Environment.IsDevelopment())
			{
				app.MapOpenApi();
				//If you are in development mode, this maps(shows) the OpenAPI/ Swagger UI.
			}
			app.UseHttpsRedirection();
			// middleware 
			// Logging purpuse 
			// req -> mw -> Logic -> next(controller) or response .
			app.UseAuthentication();
			//app.UseMiddleware<RoleCheckMiddleware>();
			app.UseAuthorization();
			// configure , configure methods 
			// using authorization middleware. 
			app.MapControllers();
			// Use all the controllers to handle HTTP requests.
			// /student/register 
			// /studnet/register -> 
			app.MapFallback(() => Results.NotFound(new
			{
				message = "Route Not Found",
				status = 404 
			})); // un handled route
			app.Run();
			// This runs your API.
		}
	}
}

