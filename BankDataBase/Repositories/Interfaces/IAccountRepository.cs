using BankDataBase.Models;

namespace BankDataBase.Repositories.Interfaces
{
	public interface IAccountRepository
	{
		Task<Account> GetAccount(uint accountId);
		Task<decimal> GetBalance(uint accountId);
		Task<string> CreateNewAccount(string accountName, uint bankId);
		Task<bool> AccountExists(uint accountId);
		Task<ICollection<Transaction>> GetSentTransactions(uint accountId);
		Task<ICollection<Transaction>> GetReceivedTransactions(uint accountId);
	}
}