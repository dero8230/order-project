using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace order_api.Models.PR
{
    public class PaperSize
    {
        public string PaperSizes { get; set; } = null!;
        public string Cost { get; set; } = null!;
        public Guid PricingId { get; set; }
    }

    public class PaperSizeConfiguration : IEntityTypeConfiguration<PaperSize>
    {
        public void Configure(EntityTypeBuilder<PaperSize> builder)
        {
            builder.HasNoKey();

            builder.Property(e => e.PaperSizes)
                .HasColumnName("PaperSizes")
                .IsRequired();

            builder.Property(e => e.Cost)
                .HasColumnName("Cost")
                .IsRequired();

            builder.HasIndex(e => e.PaperSizes);
        }
    }
}
