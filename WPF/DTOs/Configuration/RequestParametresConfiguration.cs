using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WPF.DTOs.Configuration
{
    public class RequestParametresConfiguration : IEntityTypeConfiguration<RequestParametresDTO>
    {
        public void Configure(EntityTypeBuilder<RequestParametresDTO> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
