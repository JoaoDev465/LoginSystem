using Core.Entity;

namespace Core.Interfaces;

public interface ITokenGenerator
{
   string GenerateToken(User user);
   string ValidateToken(Token token);
}