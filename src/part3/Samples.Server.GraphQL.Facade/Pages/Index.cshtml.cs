using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Samples.Server.GraphQL.Facade.Pages
{
	public class IndexModel : PageModel
	{
        // ReSharper disable once NotAccessedField.Local
		private readonly ILogger<IndexModel> _logger;

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{

		}
	}
}
