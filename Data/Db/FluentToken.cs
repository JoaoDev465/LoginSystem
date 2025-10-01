using Core.Entity;
using Core.ValueObject.TokenEntityObject;
using Core.ValueObject.UserEntityObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IdValue = Core.ValueObject.UserEntityObject.IdValue;

namespace Data.Db;

public class FluentToken: IEntityTypeConfiguration<Token>
{
    public void Configure(EntityTypeBuilder<Token> builder)
    {
        builder.ToTable("Token");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.AccessToken)
            .HasConversion(value => value.Value,
                value => new AcessToken(value))
            .HasMaxLength(200)
            .HasColumnName("AccessToken")
            .HasColumnType("Nvarchar");
        
        builder
            .Property(x => x.RefreshToken)
            .HasConversion(value => value.Value,
                value => new TokenRefresh(value))
            .HasMaxLength(200)
            .HasColumnName("RefreshToken")
            .HasColumnType("Nvarchar");

        builder
            .OwnsOne(x => x.LifeTime, lifetime =>
            {
                lifetime
                    .Property(x => x.CreatedAt)
                    .HasColumnName("CreatedAt");

                lifetime
                    .Property(x => x.ExpiredAt)
                    .HasColumnName("ExpiredAt");
            });

        builder
            .HasOne(x => x.User)
            .WithMany(x=>x.Tokens)
            .HasForeignKey(x => x.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(x => x.UserId)
            .HasConversion(value => value.Value,
                value => new IdValue(value))
            .HasColumnName("UserId");
    }
}