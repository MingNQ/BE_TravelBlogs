using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Domain.Entities.Identity;

namespace TravelBlogs.Infrastructure.Persistences.Configuration.Identity
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Subject).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(500);
            builder.HasIndex(x => x.Subject);

        }
    }
}
