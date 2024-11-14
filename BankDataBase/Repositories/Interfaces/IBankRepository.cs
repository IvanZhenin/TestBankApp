using BankDataBase.Models;

namespace BankDataBase.Repositories.Interfaces
{
	public interface IBankRepository
	{
		Bank GetBank(uint bankId);
		Bank GetBank(string bankName);
		bool BankExists(uint bankId);
		ICollection<Bank> GetBanks();
		ICollection<Account> GetAccounts(uint bankId);
		ICollection<Account> GetAccounts(string bankName);
	}
}