using System.Net;

namespace TravelBlogs.Core.Application.Common.Exceptions;

public class NotFoundException(string message) : CustomException(message, null, HttpStatusCode.NotFound);