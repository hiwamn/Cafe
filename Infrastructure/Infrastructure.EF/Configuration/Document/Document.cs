using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EF.Configuration
{
    public class Document : IEntityTypeConfiguration<Core.Entities.Document>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Document> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.DocumentType).IsRequired();
            builder.Property(p => p.Location).IsRequired();
        }
    }
}
