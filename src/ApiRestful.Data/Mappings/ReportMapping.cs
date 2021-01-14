using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApiRestful.Business.Models;

namespace ApiRestful.Data.Mappings
{
    public class ReportMapping : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Reports");
        }
    }
}
