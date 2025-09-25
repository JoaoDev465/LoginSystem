using Core.ValueObject.TokenEntityObject;

namespace Core.Entity;

public class Token
{
    public int? Id { get;private set; }
    public int UserId { get;private set; }
    public AcessToken AccessToken { get;private set; } = null!;
    public TokenRefresh RefreshToken { get;private set; } = null!;
    public TokenDateLifeTime LifeTime { get; private set; }
    public bool IsRevoked { get;private set; }
    
    private Token(){}

    public Token(int? id,
        int userId,
        AcessToken accessToken,
        TokenRefresh tokenRefresh,
        TokenDateLifeTime lifetime,
        bool isRevoked = false)
    {
        UserId = userId;
        Id = id;
        AccessToken = accessToken;
        RefreshToken = tokenRefresh;
        LifeTime = lifetime ;
    }

    public bool IsValid() => !LifeTime.IsExpired() && !IsRevoked;

    public void Revoke() => IsRevoked = true;
}
