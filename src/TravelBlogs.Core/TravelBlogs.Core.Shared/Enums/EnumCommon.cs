using System.ComponentModel;

namespace TravelBlogs.Core.Shared.Enums;

public enum FileStorageStatus
{
    [Description("Draft")]
    Draft = 1,
    [Description("Used")]
    Used = 2,
}