using System.Collections.Generic;

using ClassLibrary;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorPagesWebApplicationUI.Pages
{
	public class PersonEntryModel : PageModel
	{
		private readonly ILogger<PersonEntryModel> _logger;
		private readonly PersonModel _person;

		[BindProperty]
		public string FirstName
		{
			get; set;
		}

		[BindProperty]
		public string LastName
		{
			get; set;
		}

		[BindProperty]
		public bool IsActive
		{
			get; set;
		}

		[BindProperty]
		public List<AddressModel> Addresses
		{
			get; set;
		} = new List<AddressModel>();

		public PersonEntryModel(ILogger<PersonEntryModel> logger, PersonModel person)
		{
			_logger = logger;
			_person = person;
		}

		public void OnGet()
		{
			FirstName = _person.FirstName;
			LastName = _person.LastName;

			IsActive = _person.IsActive != null && (bool)_person.IsActive;

			Addresses = _person.Addresses;
			_logger.LogInformation("On GET Person Entry Page, Person Entry Model");
		}

		public IActionResult OnPost()
		{
			_person.FirstName = FirstName;
			_person.LastName = LastName;
			_person.IsActive = IsActive;
			_logger.LogInformation("On POST Person Entry Page, Person Entry Model, with First Name {FirstName}, Last Name {LastName}, Is Active {IsActive}, and {AddressCount} Addresses", _person.FirstName, _person.LastName, _person.IsActive, _person.Addresses.Count);
			return RedirectToPage("./Index");
		}

		public IActionResult OnPostAdd()
		{
			_person.FirstName = FirstName;
			_person.LastName = LastName;
			_person.IsActive = IsActive;
			_logger.LogInformation("On POST Person Entry Page to Add Address, Person Entry Model, with First Name {FirstName}, Last Name {LastName}, Is Active {IsActive}, and {AddressCount} Addresses", _person.FirstName, _person.LastName, _person.IsActive, _person.Addresses.Count);
			return RedirectToPage("./AddressEntry");
		}
	}
}
