using BankDataBase.Data;
using BankDataBase.Models;
using BankDataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankDataBase.Repositories
{
	public class BankRepository : IBankRepository
	{
		private readonly BankDataContext _context;
		public BankRepository(BankDataContext context)
		{
			_context = context;
		}

		public async Task<bool> BankExists(uint bankId)
		{
			var checkBank = await _context.Banks.AnyAsync(b => b.Id == bankId);
			return checkBank;
		}

		public async Task<ICollection<Account>> GetAccounts(uint bankId)
		{
			var accountList = await _context.Accounts.AsNoTracking().Where(a => a.BankId == bankId).ToListAsync();
			return accountList;
		}

		public async Task<Bank> GetBank(uint bankId)
		{
			var bank = await _context.Banks.AsNoTracking().FirstOrDefaultAsync(b => b.Id == bankId);
			return bank;
		}

		public async Task<ICollection<Bank>> GetBanks()
		{
			var bankList = await _context.Banks.AsNoTracking().ToListAsync();
			return bankList;
		}
	}
}