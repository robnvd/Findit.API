using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Findit.API
{
	public class GlobalExceptionFilter : IExceptionFilter, IDisposable
	{
		//private readonly ILogger _logger;

		//public GlobalExceptionFilter(ILoggerFactory logger)
		//{
		//	if (logger == null)
		//	{
		//		throw new ArgumentNullException(nameof(logger));
		//	}

		//	this._logger = logger.CreateLogger("Global Exception Filter");
		//}

		public void OnException(ExceptionContext context)
		{
			var response = new
			{
				Message = context.Exception.Message,
				StackTrace = context.Exception.StackTrace
			};

			context.Result = new ObjectResult(response)
			{
				StatusCode = 500,
				DeclaredType = typeof(object)
			};

			//this._logger.LogError("GlobalExceptionFilter", context.Exception);
		}

		public void Dispose()
		{
		}
	}
}
