
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
			// adds OpenAPI/Swagger support to your API.

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
			// 

            app.UseAuthorization(); 
			// configure , configure methods
			// using authorization middleware. 

			app.MapControllers();
			// Use all the controllers to handle HTTP requests.


			app.MapFallback(() => Results.NotFound(new
			{
				message = "Route Not Found",
				status = 404
			})); // un handled route

			app.Urls.Clear();
			app.Urls.Add("http://localhost:5098");
			app.Urls.Add("https://localhost:7242");

			app.Run(); 
			// This runs your API.
		}
	}
}
