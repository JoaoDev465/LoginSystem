using Core.ValueObject;
using Core.ValueObject.UserEntityObject;

namespace Core.Entity;

public class User
{
    public User(
        IdValue? id,
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
    
    private User(){}

   

    public IdValue? Id { get; private set; }
    public NameValue Name { get; private set; }  
    public EmailValue Email { get; private set; } 
    public RoleValue Roles { get; private set; } 
    public PasswordValue Password { get;private set; }

    public ICollection<Token> Tokens { get; set; } = new List<Token>();

    public void ChangeName(NameValue nameValue)
    {
        Name = nameValue ?? throw new ArgumentNullException(nameof(nameValue));
    }
    public void ChangeEmail(EmailValue emailValue)
    {
        Email = emailValue ?? throw new ArgumentNullException(nameof(emailValue));
    }
    public void ChangePassword(PasswordValue passwordValue)
    {
        Password = passwordValue ?? throw new ArgumentNullException(nameof(passwordValue));
    }
}