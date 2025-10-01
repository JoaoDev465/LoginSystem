using Core.ValueObject.TokenEntityObject;
using IdValue = Core.ValueObject.UserEntityObject.IdValue;

namespace Core.Entity;

public class Token
{
    public int? Id { get;set; }
    public AcessToken AccessToken { get;private set; } = null!;
    public TokenRefresh RefreshToken { get;private set; } = null!;
    public TokenDateLifeTime LifeTime { get;private set; }
    public bool IsRevoked { get;private set; }

    public User User { get; set; }
    
    public IdValue UserId { get;set; }
    
    private  Token(){}

    public Token(int? id,
        IdValue userId,
        AcessToken accessToken,
        TokenRefresh tokenRefresh,
        TokenDateLifeTime lifetime,
        bool isRevoked = false)
    {
        LifeTime = lifetime;
        UserId = userId;
        AccessToken = accessToken;
        RefreshToken = tokenRefresh;
        LifeTime = lifetime ;
    }

    public void ChangeAccessToken(AcessToken acessToken)
    {
        AccessToken = acessToken ?? throw new ArgumentException(nameof(acessToken));
    }
    
    public void ChangeTokenRefresh(TokenRefresh refresh)
    {
        RefreshToken = refresh?? throw new ArgumentException(nameof(refresh));
    }
    public bool IsValid() => !LifeTime.IsExpired() && !IsRevoked;

    public void Revoke() => IsRevoked = true;
}
