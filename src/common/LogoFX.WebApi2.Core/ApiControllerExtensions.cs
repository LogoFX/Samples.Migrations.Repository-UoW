using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;

// ReSharper disable once CheckNamespace
namespace System.Web.Http
{
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public static class ApiControllerExtensions
	{
		public static string GetLoggedInUserName(this ApiController controller)
		{
			return controller
					.User?
					.Identity?
					.Name?
					.Substring(
						controller.User.Identity.Name.LastIndexOf(
							"\\"
							, StringComparison.Ordinal));
		}

		public static void SetImpersonationContext(this ApiController controller)
		{
			try
			{
				((WindowsIdentity) controller.User.Identity).Impersonate();
			}
			catch (InvalidOperationException exception)
			{
				throw new UnauthorizedAccessException(exception.Message, exception);
			}
			
		}
	}

	
}
