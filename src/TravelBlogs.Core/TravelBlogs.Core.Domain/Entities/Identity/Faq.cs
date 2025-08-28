using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.Core.Domain.Common.Contracts;

namespace TravelBlogs.Core.Domain.Entities.Identity
{
    public class Faq : AuditableEntity<long>
    {
        [MaxLength(500)]
        public string Question { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string Answer { get; set; } = string.Empty;
     
        public static Faq Create(string question, string answer)
            => new() { Question = question, Answer = answer };
        public void Update(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }

    }
}
