namespace DevFreela.Infrastructure.Configurations;

public class UserSkillConfiguration : IEntityTypeConfiguration<UserSkill>
{
    public void Configure(EntityTypeBuilder<UserSkill> builder)
    {
        builder
            .HasKey(u => u.Id);
    }
}
