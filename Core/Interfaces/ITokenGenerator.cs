using Core.Entity;

namespace Core.Interfaces;

public interface ITokenGenerator
{
   Token GenerateToken(User user);
   string ValidateToken(Token token);
}