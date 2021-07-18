using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Samples.Server.GraphQL.Facade.Pages
{
	public class PrivacyModel : PageModel
	{
        // ReSharper disable once NotAccessedField.Local
        private readonly ILogger<PrivacyModel> _logger;

		public PrivacyModel(ILogger<PrivacyModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
		}
	}
}
