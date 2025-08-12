namespace TravelBlogs.Core.Shared.Constants;

public class MessageCommon
{
    public const string InitDataSuccess = "Init data successfully";
    public const string GetDataSuccess = "Get data successfully";
    public const string CreateSuccess = "Create successfully";
    public const string CreateFailed = "Create failed";
    public const string UpdateSuccess = "Update successfully";
    public const string UpdateFailed = "Update failed";
    public const string DeleteSuccess = "Delete successfully";
    public const string DeleteFailed = "Delete failed";
    public const string DataNotFound = "Can't find entity to get";
    public const string CannotUpdateStatus = "Can't update status";
    public const string UserUpdateStatusSuccessful = "Status ser has been updated successfully";
    public const string ArchiveSuccess = "Archive record successfully";
    public const string UnArchiveSuccess = "Unarchive record successfully";
    public const string ImportSuccess = "Import successful";
    public const string ImportFailed = "Import failed";
    public const string UploadSuccess = "Upload successful";
    public const string AssignSuccess = "Assign successfully";

    public static string SetEntityNotFound(string entityName, object id) => $"{entityName} id {id} not found.";

    public static string SetEntityDoesNotPermission(string entityName, string action) => $"You do not have permission to {action} this {entityName}.";

    public static string SetEntityDoesNotEdit(string entityName) => $"Cannot edit {entityName} in the current status.";

    public static string SetEntityExists(string entityName, object id) => $"{entityName} id {id} has been exist.";
}