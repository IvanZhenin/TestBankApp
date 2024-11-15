using BankDataBase.Models;

namespace BankDataBase.Repositories.Interfaces
{
	public interface IBankRepository
	{
		Task<Bank> GetBank(uint bankId);
		Task<bool> BankExists(uint bankId);
		Task<ICollection<Bank>> GetBanks();
		Task<ICollection<Account>> GetAccounts(uint bankId);
	}
}