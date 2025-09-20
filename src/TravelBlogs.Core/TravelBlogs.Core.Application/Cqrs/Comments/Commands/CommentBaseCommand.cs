namespace TravelBlogs.Core.Application.Cqrs.Comments.Commands;

public class CommentBaseCommand
{
    public string Content { get; set; } = string.Empty;
}