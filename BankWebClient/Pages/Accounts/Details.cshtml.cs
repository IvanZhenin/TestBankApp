using BankDtoModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankWebClient.Pages.Accounts
{
    public class DetailsModel : PageModel
    {
	    private readonly IHttpClientFactory _httpClientFactory;
		public DetailsModel(IHttpClientFactory httpClientFactory)
	    {
		    _httpClientFactory = httpClientFactory;
	    }

	    public AccountDto? Account { get; private set; }
	    public List<TransactionDto>? SentTransactions { get; private set; }
	    public List<TransactionDto>? ReceivedTransactions { get; private set; }

		public async Task<IActionResult> OnGetAsync(uint accountId)
		{
			var client = _httpClientFactory.CreateClient("BankWebService");
			Account = await client.GetFromJsonAsync<AccountDto>($"api/Account/accounts/{accountId}");

			if (Account == null)
			{
				return NotFound();
			}
			else
			{
				SentTransactions = await client.GetFromJsonAsync<List<TransactionDto>>(
					$"api/Account/accounts/{accountId}/SentTransactions");

				ReceivedTransactions = await client.GetFromJsonAsync<List<TransactionDto>>(
					$"api/Account/accounts/{accountId}/ReceivedTransactions");
			}

			return Page();
		}
	}
}
