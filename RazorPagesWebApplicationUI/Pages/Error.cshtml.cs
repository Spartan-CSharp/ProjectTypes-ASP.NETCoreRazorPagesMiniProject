using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorPagesWebApplicationUI.Pages
{
	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public class ErrorModel : PageModel
	{
		public string RequestId { get; set; }

		public bool ShowRequestId
		{
			get
			{
				return !string.IsNullOrEmpty(RequestId);
			}
		}

		private readonly ILogger<ErrorModel> _logger;

		public ErrorModel(ILogger<ErrorModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
			RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
			_logger.LogInformation("On GET Error Page, Error Model, with RequestId = {RequestId}", RequestId);
		}
	}
}
