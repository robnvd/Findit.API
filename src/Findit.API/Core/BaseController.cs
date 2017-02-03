using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Findit.API.Core
{
    [Authorize]
	[Route("api/[controller]")]
	[EnableCors("AllowAll")]
	public class BaseController : Controller
	{

	}
}
