using BankDataBase.Data;
using BankDataBase.Models;
using BankDataBase.Repositories.Interfaces;
using BankDataBase.Utilities;
using Microsoft.EntityFrameworkCore;

namespace BankDataBase.Repositories
{
	public class AccountRepository : IAccountRepository
	{
		private readonly BankDataContext _context;
		public AccountRepository(BankDataContext context)
		{
			_context = context;
		}

		public async Task<bool> AccountExists(uint accountId)
		{
			var checkAccount = await _context.Accounts.AnyAsync(a => a.Id == accountId);
			return checkAccount;
		}

		public async Task<string> CreateNewAccount(string accountName, uint bankId)
		{
			if (String.IsNullOrEmpty(accountName))
				return "Ошибка: не указано имя!";

			if(!await _context.Banks.AnyAsync(b => b.Id == bankId))
				return "Ошибка: банк не найден!";

			var accountIdList = await _context.Accounts.AsNoTracking()
				.OrderBy(a => a.Id).Select(a => a.Id).ToListAsync();

			using (var transact = await _context.Database.BeginTransactionAsync())
			{
				try
				{
					var account = new Account()
					{
						Id = UniqueIdProvider.GetNewUintId(accountIdList),
						AccountName = accountName,
						BankId = bankId,
						CreationDate = DateTime.Now,
						Balance = 0,
					};

					_context.Accounts.Add(account);
					await _context.SaveChangesAsync();

					await transact.CommitAsync();
					return "Аккаунт успешно создан!";
				}
				catch (Exception ex)
				{
					await transact.RollbackAsync();
					return $"Произошла критическая ошибка!\n {ex.ToString()}";
				}
			}
		}

		public async Task<Account> GetAccount(uint accountId)
		{
			var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
			return account;
		}

		public async Task<decimal> GetBalance(uint accountId)
		{
			var account = await _context.Accounts.AsNoTracking().FirstOrDefaultAsync(a => a.Id == accountId);
			return account?.Balance ?? 0;
		}

		public async Task<ICollection<Transaction>> GetSentTransactions(uint accountId)
		{
			var transactionList = await _context.Transactions.AsNoTracking().Where(t => t.SenderId == accountId).ToListAsync();
			return transactionList;
		}

		public async Task<ICollection<Transaction>> GetReceivedTransactions(uint accountId)
		{
			var transactionList = await _context.Transactions.AsNoTracking().Where(t => t.RecipientId == accountId).ToListAsync();
			return transactionList;
		}
	}
}