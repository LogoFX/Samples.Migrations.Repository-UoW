using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace LogoFX.WebApi2.Core
{
	/// <summary>Represents the attributes for the exception filter.</summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class ExceptionFilterAttribute : System.Web.Http.Filters.ExceptionFilterAttribute
	{
		/// <summary>Raises the exception event.</summary>
		/// <param name="actionExecutedContext">The context for the action.</param>
		public override void OnException(HttpActionExecutedContext actionExecutedContext)
		{
			var exception = actionExecutedContext.Exception;
			var status = TranslateExceptionToStatusCode(exception);
			var response = actionExecutedContext.Request.CreateErrorResponse(status, exception);
			actionExecutedContext.Response = response;
		}
		
		private static HttpStatusCode TranslateExceptionToStatusCode(Exception exception)
		{
			if (exception is NotImplementedException)
			{
				return HttpStatusCode.NotImplemented;
			}

			if (exception is UnauthorizedAccessException)
			{
				return HttpStatusCode.Unauthorized;
			}

			if (exception is FileNotFoundException)
			{
				return HttpStatusCode.NotFound;
			}

			
			return HttpStatusCode.InternalServerError;
		}
	}
}