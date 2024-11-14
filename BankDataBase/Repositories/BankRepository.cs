using BankDataBase.Data;
using BankDataBase.Models;
using BankDataBase.Repositories.Interfaces;

namespace BankDataBase.Repositories
{
	public class BankRepository : IBankRepository
	{
		private readonly BankDataContext _context;
		public BankRepository(BankDataContext context)
		{
			_context = context;
		}

		public bool BankExists(uint bankId)
		{
			return _context.Banks.Any(b => b.Id == bankId);
		}

		public ICollection<Account> GetAccounts(uint bankId)
		{
			return _context.Accounts.Where(a => a.BankId == bankId).ToList();
		}

		public ICollection<Account> GetAccounts(string bankName)
		{
			return _context.Accounts.Where(a => a.Bank.BankName == bankName).ToList();
		}

		public Bank GetBank(uint bankId)
		{
			return _context.Banks.FirstOrDefault(b => b.Id == bankId);
		}

		public Bank GetBank(string bankName)
		{
			return _context.Banks.FirstOrDefault(b => b.BankName == bankName);
		}

		public ICollection<Bank> GetBanks()
		{
			return _context.Banks.ToList();
		}
	}
}