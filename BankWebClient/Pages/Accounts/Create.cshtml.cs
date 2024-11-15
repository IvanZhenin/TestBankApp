using BankDtoModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankWebClient.Pages.Accounts
{
    public class CreateModel : PageModel
    {
	    private readonly IHttpClientFactory _httpClientFactory;
	    public CreateModel(IHttpClientFactory httpClientFactory)
	    {
		    _httpClientFactory = httpClientFactory;
	    }


		[BindProperty(SupportsGet = true)]
		public uint BankId { get; set; }

	    [BindProperty]
	    public NewAccountDto Account { get; set; }

	    public void OnGet()
	    {
		    Account = new NewAccountDto { BankId = BankId };
	    }

	    public async Task<IActionResult> OnPostAsync()
	    {
		    if (!ModelState.IsValid)
		    {
			    return Page();
		    }

		    var client = _httpClientFactory.CreateClient("BankWebService");
		    var response = await client.PostAsJsonAsync("api/Account/", Account);

		    if (response.IsSuccessStatusCode)
		    {
			    return RedirectToPage("/Banks/Details", new { bankId = Account.BankId });
		    }

		    return Page();
	    }
	}
}