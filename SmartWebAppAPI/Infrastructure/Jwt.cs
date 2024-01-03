using Microsoft.IdentityModel.Tokens;
using SmartWebAppAPI.Entity.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SmartWebAppAPI.Infrastructure
{
  public class Jwt
  {
    private readonly string _secretKey;
    private readonly string _issuer;
    private readonly string _audience;

    public Jwt(string secretKey, string issuer, string audience)
    {
      _secretKey = secretKey;
      _issuer = issuer;
      _audience = audience;
    }

    public string GenerateToken(string userId, string userType)
    {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var claims = new[]
      {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("userType", userType)
        };

      var token = new JwtSecurityToken(
          issuer: _issuer,
          audience: _audience,
          claims: claims,
          expires: DateTime.UtcNow.AddHours(1),
          signingCredentials: credentials
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}
