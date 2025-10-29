namespace TravelBlogs.Core.Domain.Common.Enums;

public enum BlogStatusEnum //trạng thái xét duyệt của bài blog.
{
    InReview = 1, //đang xem xét
    Approved = 2, //đã phê duyệt
    Rejected = 3, //từ chối
    Cancelled = 4
}

public enum FeedbackTypeEnum //loại phản hồi
{
    Comment = 1, //bình luận
    Suggestion = 2, //góp ý
    Complaint = 3, //khiếu nại
    Question = 4 //câu hỏi
}

public enum FeedbackStatusEnum //trạng thái xử lý của phản hồi
{
    Pending = 1, //chờ xử lý
    Approved = 2, //đã xử lý
    Rejected = 3, //từ chối
    Resolved = 4 //đã xử lý
}

public enum FeedbackRegardingEnum  //liên quan đến phản hồi
{
    Content = 1, //nội dung
    Quality = 2, //chất lượng
    Accuracy = 3, //độ chính xác
    Presentation = 4, //trình bày
    Other = 5 //khác
}