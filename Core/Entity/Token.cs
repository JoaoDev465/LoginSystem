using Core.ValueObject.TokenEntityObject;

namespace Core.Entity;

public class Token
{
    public int? Id { get;set; }
    public int UserId { get;set; }
    public AcessToken AccessToken { get;private set; } = null!;
    public TokenRefresh RefreshToken { get;private set; } = null!;
    public TokenDateLifeTime LifeTime { get; set; }
    public bool IsRevoked { get;private set; }
    
    public  Token(){}

    public Token(int? id,
        int userId,
        AcessToken accessToken,
        TokenRefresh tokenRefresh,
        TokenDateLifeTime lifetime,
        bool isRevoked = false)
    {
        AccessToken = accessToken;
        RefreshToken = tokenRefresh;
        LifeTime = lifetime ;
    }

    public bool IsValid() => !LifeTime.IsExpired() && !IsRevoked;

    public void Revoke() => IsRevoked = true;
}
