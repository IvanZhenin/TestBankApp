using AutoMapper;
using BankDataBase.Repositories;
using BankDataBase.Repositories.Interfaces;
using BankDtoModels;
using Microsoft.AspNetCore.Mvc;

namespace BankWebService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : Controller
	{
		private readonly IAccountRepository _accountRepository;
		private readonly IMapper _mapper;

		public AccountController(IAccountRepository accountRepository, IMapper mapper)
		{
			_accountRepository = accountRepository;
			_mapper = mapper;
		}

		[HttpGet("Accounts/{accountId}")]
		public async Task<IActionResult> GetAccount(uint accountId)
		{
			if (!await _accountRepository.AccountExists(accountId))
				return NotFound();

			var account = _mapper.Map<AccountDto>(await _accountRepository.GetAccount(accountId));

			if (account == null)
				return BadRequest(ModelState);

			return Ok(account);
		}

		[HttpGet("Accounts/{accountId}/SentTransactions")]
		public async Task<IActionResult> GetAccountSentTransactions(uint accountId)
		{
			if (!await _accountRepository.AccountExists(accountId))
				return NotFound();

			var transactions =_mapper.Map<List<TransactionDto>>(
				await _accountRepository.GetSentTransactions(accountId));

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(transactions);
		}

		[HttpGet("Accounts/{accountId}/ReceivedTransactions")]
		public async Task<IActionResult> GetAccountReceivedTransactions(uint accountId)
		{
			if (!await _accountRepository.AccountExists(accountId))
				return NotFound();

			var transactions = _mapper.Map<List<TransactionDto>>(
				await _accountRepository.GetReceivedTransactions(accountId));

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(transactions);
		}

		[HttpPost]
		public async Task<IActionResult> CreateNewAccount([FromBody] NewAccountDto accountDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = await _accountRepository.CreateNewAccount(accountDto.AccountName, accountDto.BankId);
			
			if (result.StartsWith("Ошибка") || result.StartsWith("Произошла"))
				return BadRequest(ModelState);

			return Ok(result);
		}
	}
}