using Core.ValueObject;

namespace Core.Entity;

public class User
{
    public User(
        IdValue id,
        NameValue name,
        EmailValue email,
        PasswordValue password,
        RoleValue roles)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        Roles = roles;
    }
    public IdValue Id { get; set; }
    public NameValue Name { get; set; }  
    public EmailValue Email { get; set; } 
    public RoleValue Roles { get; set; } 
    public PasswordValue Password { get; set; }
}