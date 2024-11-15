using BankDtoModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankWebClient.Pages.Banks
{
    public class ListModel : PageModel
    {
	    private readonly IHttpClientFactory _httpClientFactory;

	    public ListModel(IHttpClientFactory httpClientFactory)
	    {
		    _httpClientFactory = httpClientFactory;
	    }

	    public List<BankDto>? Banks { get; private set; } = [];
	    public async Task OnGetAsync()
	    {
			var client = _httpClientFactory.CreateClient("BankWebService");
			Banks = await client.GetFromJsonAsync<List<BankDto>>("api/Bank/Banks");
	    }
	}
}