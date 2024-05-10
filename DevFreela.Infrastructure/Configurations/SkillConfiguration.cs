namespace DevFreela.Infrastructure.Configurations;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder
            .HasKey(s => s.Id);
    }
}
