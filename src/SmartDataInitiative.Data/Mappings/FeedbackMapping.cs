using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartDataInitiative.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDataInitiative.Data.Mappings
{
    public class FeedbackMapping : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("varchar(2000)");

            builder.ToTable("Feedbacks");
        }
    }
}
