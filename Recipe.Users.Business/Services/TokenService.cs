using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Recipe.Users.Business.Dtoes;
using Recipe.Users.Business.Interfaces;

namespace Recipe.Users.Business.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public string CreateToken(UserDTO user)
    {
        string jwtKey = this._configuration.GetSection("JwtSettings:Key").Value;


        if (string.IsNullOrEmpty(jwtKey) || jwtKey.Length < 16)
        {
            throw new Exception("The JWT key is not valid. It must be at least 16 characters long.");
        }

        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
        };

       

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));


        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
         claims: claims,
         expires: DateTime.Now.AddDays(1),
         signingCredentials: cred
     );
        string jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}