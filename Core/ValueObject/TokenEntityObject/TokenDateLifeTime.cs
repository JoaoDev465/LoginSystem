using Core.Exceptions.TokenExceptions;
using Microsoft.EntityFrameworkCore;

namespace Core.ValueObject.TokenEntityObject;

[Owned]
public class TokenDateLifeTime : ValueObject
{
    
    public TokenDateLifeTime(DateTime? createdat, DateTime? expiredat)
    {
        CreatedAt = createdat;
        ExpiredAt = expiredat;
        
        TokenLifeTimeException.ThrowLifeTimeIsInvalid
            (createdat,expiredat,"CreatedAt cannot be greater than expiredAt");
    }
    
    private TokenDateLifeTime(){}

    public DateTime? ExpiredAt{ get;  }
    public DateTime? CreatedAt { get;  }

    public bool IsExpired() => CreatedAt >= ExpiredAt;
}