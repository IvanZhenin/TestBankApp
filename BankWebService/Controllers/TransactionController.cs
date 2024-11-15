using AutoMapper;
using BankDataBase.Repositories;
using BankDataBase.Repositories.Interfaces;
using BankDtoModels;
using Microsoft.AspNetCore.Mvc;

namespace BankWebService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TransactionController : Controller
	{
		private readonly ITransactionRepository _transactionRepository;
		private readonly IMapper _mapper;

		public TransactionController(ITransactionRepository transactionRepository, IMapper mapper)
		{
			_transactionRepository = transactionRepository;
			_mapper = mapper;
		}

		[HttpPost]
		public async Task<IActionResult> CreateNewTransaction([FromBody] NewTransactionDto transactionDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = await _transactionRepository.CreateNewTransaction(transactionDto.SenderId,
				transactionDto.RecipientId, transactionDto.TransactionAmount);

			if (result.StartsWith("Ошибка") || result.StartsWith("Произошла"))
				return BadRequest(ModelState);

			return Ok(result);
		}
	}
}