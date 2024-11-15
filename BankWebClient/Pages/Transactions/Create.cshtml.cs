using BankDtoModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankWebClient.Pages.Transactions
{
    public class CreateModel : PageModel
    {
	    private readonly IHttpClientFactory _httpClientFactory;

	    public CreateModel(IHttpClientFactory httpClientFactory)
	    {
		    _httpClientFactory = httpClientFactory;
	    }

	    [BindProperty(SupportsGet = true)]
		public uint AccountId { get; set; }

		[BindProperty]
	    public NewTransactionDto Transaction { get; set; }

		public void OnGet()
		{
			
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			var client = _httpClientFactory.CreateClient("BankWebService");

			var response = await client.PostAsJsonAsync("api/Transaction", Transaction);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToPage("/Accounts/Details", new { accountId = Transaction.SenderId });
			}

			ModelState.AddModelError(string.Empty, "Ошибка при создании транзакции.");
			return Page();
		}
	}
}