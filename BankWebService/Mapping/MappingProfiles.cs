using AutoMapper;
using BankDataBase.Models;
using BankDtoModels;

namespace BankWebService.Mapping
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<Bank, BankDto>();
			CreateMap<Account, NewAccountDto>();
			CreateMap<Account, AccountDto>();
			CreateMap<Transaction, NewTransactionDto>();
			CreateMap<Transaction, TransactionDto>();
		}
	}
}