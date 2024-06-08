namespace DevFreela.Infrastructure.Configurations;

public class ProjectCommentConfiguration : IEntityTypeConfiguration<ProjectComment>
{
    public void Configure(EntityTypeBuilder<ProjectComment> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Content)
            .HasColumnType("varchar")
            .HasMaxLength(1000)
            .IsRequired();

        builder
            .Property(x => x.CreatedAt)
            .HasColumnType("datetime")
            .IsRequired();

        #region Foreign Key

        builder
            .HasOne(pc => pc.Project)
            .WithMany(p => p.Comments)
            .HasForeignKey(pc => pc.IdProject);

        builder
            .HasOne(pc => pc.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(pc => pc.IdUser);

        #endregion
    }
}
