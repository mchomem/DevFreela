namespace DevFreela.Infrastructure.Configurations;

public class ProjectCommentConfiguration : IEntityTypeConfiguration<ProjectComment>
{
    public void Configure(EntityTypeBuilder<ProjectComment> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .HasOne(pc => pc.Project)
            .WithMany(p => p.Comments)
            .HasForeignKey(pc => pc.IdProject);

        builder
            .HasOne(pc => pc.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(pc => pc.IdUser);
    }
}
