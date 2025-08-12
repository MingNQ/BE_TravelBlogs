using Microsoft.AspNetCore.Mvc;

namespace TravelBlogs.Presentation.Host.Controllers.Base;

[Route("api/v{version:apiVersion}/[controller]")]
public class VersionedApiController : BaseApiController;