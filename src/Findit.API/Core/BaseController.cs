﻿using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Findit.API.Core
{
	[Authorize]
	[Route("api/[controller]")]
	public class BaseController : Controller
	{
		
	}
}
