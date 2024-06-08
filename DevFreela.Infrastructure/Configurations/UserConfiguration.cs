namespace DevFreela.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.FullName)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(x => x.Email)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(x => x.BirthDate)
            .HasColumnType("datetime")
            .IsRequired();

        builder
            .Property(x => x.CreatedAt)
            .HasColumnType("datetime")
            .IsRequired();

        builder
            .Property(x => x.Active)
            .HasColumnType("bit")
            .IsRequired();

        builder        
            .Property(x => x.Password)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(x => x.Role)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .IsRequired();

        #region Foreign Key

        builder
            .HasMany(u => u.Skills)
            .WithOne()
            .HasForeignKey(u => u.IdSkill)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion
    }
}
