using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartDataInitiative.Business.Models;


namespace SmartDataInitiative.Data.Mappings
{
    public class ProjectMapping : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("varchar(2000)");

            // 1 : N => Project : Fields
            builder.HasMany(f => f.Fields)
                .WithOne(p => p.Project)
                .HasForeignKey(p => p.ProjectId);

            // 1 : N => Project : ReportModels
            builder.HasMany(f => f.ReportModels)
                .WithOne(p => p.Project)
                .HasForeignKey(p => p.ProjectId);

            builder.ToTable("Projects");

        }
    }
}
