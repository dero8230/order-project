using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace order_api.Models.PR
{
    public class ActiveJob
    {
        public string ActiveJobNumbers { get; set; } = null!;
        public string Name { get; set; } = null!;
    }

    public class ActiveJobConfiguration : IEntityTypeConfiguration<ActiveJob>
    {
        public void Configure(EntityTypeBuilder<ActiveJob> builder)
        {
            builder.HasNoKey();

            builder.Property(e => e.ActiveJobNumbers)
                .HasColumnName("ActiveJobNumbers")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .IsRequired();

            builder.HasIndex(e => e.ActiveJobNumbers);
        }
    }
}
