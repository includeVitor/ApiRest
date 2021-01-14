using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApiRestful.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRestful.Data.Mappings
{
    public class ReportModelMapping : IEntityTypeConfiguration<ReportModel>
    {
        public void Configure(EntityTypeBuilder<ReportModel> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("varchar(2000)");

            // 1 : N => ReportModel : Models
            builder.HasMany(f => f.Models)
                .WithOne(p => p.ReportModel)
                .HasForeignKey(p => p.ReportModelId);

            builder.ToTable("ReportModels");
        }
    }
}
