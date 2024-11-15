using AutoMapper;
using BankDataBase.Repositories.Interfaces;
using BankDtoModels;
using Microsoft.AspNetCore.Mvc;

namespace BankWebService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BankController : Controller
	{
		private readonly IBankRepository _bankRepository;
		private readonly IMapper _mapper;

		public BankController(IBankRepository bankRepository, IMapper mapper)
		{
			_bankRepository = bankRepository;
			_mapper = mapper;
		}

		[HttpGet("Banks")]
		public async Task<IActionResult> GetBanks()
		{
			var banks = _mapper.Map<List<BankDto>>(await _bankRepository.GetBanks());

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(banks);
		}

		[HttpGet("Banks/{bankId}")]
		public async Task<IActionResult> GetBank(uint bankId)
		{
			if (!await _bankRepository.BankExists(bankId))
				return NotFound();

			var bank = _mapper.Map<BankDto>(await _bankRepository.GetBank(bankId));

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(bank);
		}

		[HttpGet("Accounts/{bankId}")]
		public async Task<IActionResult> GetAccounts(uint bankId)
		{
			var accounts = _mapper.Map<List<AccountDto>>(await _bankRepository.GetAccounts(bankId));

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(accounts);
		}
	}
}