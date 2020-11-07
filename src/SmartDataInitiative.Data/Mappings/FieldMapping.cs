using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartDataInitiative.Business.Models;

namespace SmartDataInitiative.Data.Mappings
{
    public class FieldMapping : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("varchar(2000)");

            // 1 : N => Field : Reports
            builder.HasMany(f => f.Reports)
                .WithOne(p => p.Field)
                .HasForeignKey(p => p.FieldId);


            builder.ToTable("Fields");
        }
    }
}
