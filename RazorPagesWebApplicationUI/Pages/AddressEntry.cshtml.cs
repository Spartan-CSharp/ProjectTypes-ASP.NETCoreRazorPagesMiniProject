using ClassLibrary;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorPagesWebApplicationUI.Pages
{
	public class AddressEntryModel : PageModel
	{
		private readonly ILogger<AddressEntryModel> _logger;
		private readonly PersonModel _person;
		private readonly AddressModel _address;

		[BindProperty]
		public string StreetAddress
		{
			get; set;
		}

		[BindProperty]
		public string City
		{
			get; set;
		}

		[BindProperty]
		public string State
		{
			get; set;
		}

		[BindProperty]
		public string ZipCode
		{
			get; set;
		}

		public AddressEntryModel(ILogger<AddressEntryModel> logger, PersonModel person, AddressModel address)
		{
			_logger = logger;
			_person = person;
			_address = address;
		}

		public void OnGet()
		{
			_logger.LogInformation("On GET Address Entry Page, Address Entry Model");
		}

		public IActionResult OnPost()
		{
			_address.StreetAddress = StreetAddress;
			_address.City = City;
			_address.State = State;
			_address.ZipCode = ZipCode;
			_person.Addresses.Add(_address);
			_logger.LogInformation("On POST Address Entry Page, Address Entry Model, with Address {StreetAddress}, {City}, {State} {ZipCode}", StreetAddress, City, State, ZipCode);
			return RedirectToPage("./PersonEntry");
		}
	}
}
