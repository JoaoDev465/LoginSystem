using System.Security.Claims;
using Core.Entity;

namespace Core.Interfaces;

public interface ITokenGenerator
{
   Token GenerateToken(User user);
   ClaimsPrincipal? ValidateToken(Token token);
}