namespace Core.ValueObject.TokenEntityObject;

public class TokenDateLifeTime
{
    public TokenDateLifeTime(DateTime createdat, DateTime expiredat)
    {
        CreatedAt = createdat;
        ExpiredAt = expiredat;
    }

    public DateTime ExpiredAt{ get;  }
    public DateTime CreatedAt { get;  } = DateTime.UtcNow;

    public bool IsExpired() => CreatedAt >= ExpiredAt;
}