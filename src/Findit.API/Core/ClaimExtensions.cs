using System;
using System.Security.Claims;
using System.Linq;
using System.Security.Principal;

namespace Findit.API.Core
{
	public static class ClaimExtensions
	{
		public static string GetClaim(this IIdentity claimsIdentity, string claimType)
		{
			if (claimsIdentity is ClaimsIdentity)
			{
				var identity = claimsIdentity as ClaimsIdentity;
				var claims = identity.Claims.ToList();
				var claim = claims.FirstOrDefault(x => x.Type == claimType);
				return claim?.Value ?? string.Empty;
			}
			return string.Empty;
		}
	}
}
