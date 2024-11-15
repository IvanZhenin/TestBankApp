using BankDtoModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankWebClient.Pages.Banks
{
    public class DetailsModel : PageModel
    {
	    private readonly IHttpClientFactory _httpClientFactory;

	    public DetailsModel(IHttpClientFactory httpClientFactory)
	    {
		    _httpClientFactory = httpClientFactory;
	    }

		public BankDto? Bank { get; private set; }
		public List<AccountDto>? Accounts { get; private set; }

		public async Task<IActionResult> OnGetAsync(uint bankId)
	    {
		    var client = _httpClientFactory.CreateClient("BankWebService");
		    Bank = await client.GetFromJsonAsync<BankDto>($"api/Bank/Banks/{bankId}");
		    
			if (Bank == null)
		    {
			    return NotFound();
		    }
			else
			{
				Accounts = await client.GetFromJsonAsync<List<AccountDto>>($"api/Bank/Accounts/{bankId}");
			}

		    return Page();
	    }
    }
}
