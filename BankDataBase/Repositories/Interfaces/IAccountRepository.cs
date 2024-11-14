using BankDataBase.Models;

namespace BankDataBase.Repositories.Interfaces
{
	public interface IAccountRepository
	{
		Account GetAccount(uint accountId);
		decimal GetBalance(uint accountId);
		string CreateNewAccount(string accountName, uint bankId);
		bool AccountExists(uint accountId);
		ICollection<Transaction> GetSentTransactions(uint accountId);
		ICollection<Transaction> GetReceivedTransactions(uint accountId);
	}
}