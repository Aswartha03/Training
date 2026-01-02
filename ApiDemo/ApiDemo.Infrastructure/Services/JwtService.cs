using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiDemo.Core.Entities;
using ApiDemo.Core.Models.AuthModels;
using Microsoft.IdentityModel.Tokens;

namespace ApiDemo.Infrastructure.Services
{
    static public class JwtService
    {
        public static  string GenerateToken(User user)
		{
		        //JWT token = claims + secret key + expiry → signed → returned as string
			var claims = new[] // claims about the user
            {
                new Claim(ClaimTypes.Name, user.Username) ,
				new Claim(ClaimTypes.Role, user.Role) 
			};
			// secret key	
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("8F2a9#XzPqL!9K@3R7mW$H4D1sB6ZQvC"));
			// signing credentials
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			// create the token
			var token = new JwtSecurityToken(
                issuer: "StudentApi",
                audience: "Students",
                claims: claims,
                expires: DateTime.Now.AddHours(1),// expiry time is one hour for token
				signingCredentials: creds 
				);
			// return the token as a string
			return new JwtSecurityTokenHandler().WriteToken(token);
		}   
			
		
	}
}
