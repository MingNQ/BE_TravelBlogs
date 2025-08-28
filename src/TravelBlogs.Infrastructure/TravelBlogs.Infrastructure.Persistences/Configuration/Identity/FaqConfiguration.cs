using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.Core.Domain.Entities.Identity;

namespace TravelBlogs.Infrastructure.Persistences.Configuration.Identity
{
    public class FaqConfiguration : IEntityTypeConfiguration<Faq>
    {
        public void Configure(EntityTypeBuilder<Faq> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Question).IsRequired().HasMaxLength(500);   
            builder.Property(x => x.Answer).IsRequired().HasMaxLength(2000);
            builder.HasIndex(x => x.Question);
        }
    }
}
