using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WPF.DTOs.Configuration
{
    public class ScenarioConfiguration : IEntityTypeConfiguration<ScenarioDTO>
    {
        public void Configure(EntityTypeBuilder<ScenarioDTO> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type)
                .HasConversion<string>()
                .IsRequired();

            builder
                .HasOne(s => s.RequestParametres)
                .WithMany(r => r.Scenarios)
                .HasForeignKey(s => s.RequestParametresId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
