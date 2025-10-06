using Core.Entity;
using Core.ValueObject.UserEntityObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Db;

public class FluentUser: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .HasConversion(id => id!.Value,
                id => new IdValue(id))
            .ValueGeneratedOnAdd().UseIdentityColumn();

        builder
            .Property(x => x.Email)
            .HasConversion(email => email.Email,
                email => new EmailValue(email))
            .HasColumnName("Email")
            .HasColumnType("Nvarchar")
            .HasMaxLength(150);

        builder
            .Property(x => x.Name)
            .HasConversion(value => value.Name,
                value => new NameValue(value))
            .HasColumnName("Name")
            .HasColumnType("Nvarchar")
            .HasMaxLength(150);

        builder
            .Property(x => x.Password)
            .HasConversion(password => password.Password,
                password => new PasswordValue(password))
            .HasColumnName("Password")
            .HasColumnType("Nvarchar")
            .HasMaxLength(200);

        builder
            .Property(x => x.Roles)
            .HasConversion(
                role => string.Join(",", role.Role),
                role => new RoleValue(role.Split(',',StringSplitOptions.RemoveEmptyEntries))
            )
            .HasColumnName("Role")
            .HasColumnType("Nvarchar")
            .HasMaxLength(100);

    }
}