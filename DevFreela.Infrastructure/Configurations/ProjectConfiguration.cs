namespace DevFreela.Infrastructure.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Title)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property (x => x.Description)
            .HasColumnType("varchar")
            .HasMaxLength(3000)
            .IsRequired();

        builder
            .Property(x => x.TotalCost)
            .HasColumnType("decimal(18,2)")
            .IsRequired(false);

        builder
            .Property(x => x.CreatedAt)
            .HasColumnType("datetime")
            .IsRequired();

        builder
            .Property(x => x.StartedAt)
            .HasColumnType("datetime")
            .IsRequired(false);

        builder
            .Property(x => x.FinishedAt)
            .HasColumnType("datetime")
            .IsRequired(false);

        builder
            .Property(x => x.Status)
            .HasColumnType("int")
            .IsRequired();

        #region Foreign Key

        builder
            .HasOne(p => p.Freelancer)
            .WithMany(f => f.FreeLanceProjects)
            .HasForeignKey(p => p.IdFreelancer)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(p => p.Client)
            .WithMany(f => f.OwnedProjects)
            .HasForeignKey(p => p.IdClient)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion
    }
}
