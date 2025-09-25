using Core.Exceptions.TokenExceptions;

namespace Core.ValueObject.TokenEntityObject;

public class TokenDateLifeTime : ValueObject
{
    public TokenDateLifeTime(DateTime? createdat, DateTime? expiredat)
    {
        CreatedAt = createdat;
        ExpiredAt = expiredat;
        
        TokenLifeTimeException.ThrowLifeTimeNull(createdat,expiredat,
            "createdat and expiredat can't be null");
    }

    public DateTime? ExpiredAt{ get;  }
    public DateTime? CreatedAt { get;  }

    public bool IsExpired() => CreatedAt >= ExpiredAt;
}