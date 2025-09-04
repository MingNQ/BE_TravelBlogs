namespace TravelBlogs.Core.Application.Cqrs.Contacts.Commands
{
    public class ContactBaseCommand
    {
        public string Subject { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public long UserId { get; set; }
    }
}