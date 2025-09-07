using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.Core.Domain.Common.Contracts;
using TravelBlogs.Core.Domain.Entities.Identity;

namespace TravelBlogs.Core.Domain.Entities.Catalog
{
    public class Contact : AuditableEntity<long>
    {

        [Required]
        [MaxLength(100)]
        public string Subject {  get; set; } = string.Empty;
        [Required]
        [MaxLength(500)]
        public string Content { get; set; } = string.Empty;
        public long UserId { get; set; }
        public User? User { get; set; }
        private Contact() { }
        public void Update(string subject, string content)
        {
            Subject = subject;
            Content = content;
        }

        public static Contact Create(string subject, string content, long userId)
        {
           return new Contact() { Subject = subject, Content = content, UserId = userId };
        }
    }
}
