using System.Net;

namespace TravelBlogs.Core.Application.Common.Exceptions;

public class ForbiddenException(string message) : CustomException(message, null, HttpStatusCode.Forbidden);