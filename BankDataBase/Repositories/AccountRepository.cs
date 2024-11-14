using BankDataBase.Data;
using BankDataBase.Models;
using BankDataBase.Repositories.Interfaces;
using BankDataBase.Utilities;

namespace BankDataBase.Repositories
{
	public class AccountRepository : IAccountRepository
	{
		private readonly BankDataContext _context;
		public AccountRepository(BankDataContext context)
		{
			_context = context;
		}

		public bool AccountExists(uint accountId)
		{
			return _context.Accounts.Any(a => a.Id == accountId);
		}

		public string CreateNewAccount(string accountName, uint bankId)
		{
			if (String.IsNullOrEmpty(accountName))
				return "Не удалось создать аккаунт, необходимо указать имя!";

			if (!_context.Banks.Any(b => b.Id == bankId))
				return "Не удалось создать аккаунт, неверно указан номер банка!";

			var accountList = _context.Accounts.OrderBy(a => a.Id).Select(a => a.Id).ToList();

			var account = new Account()
			{
				Id = UniqueIdProvider.GetNewUintId(accountList),
				AccountName = accountName,
				BankId = bankId,
				CreationDate = DateTime.Now,
				Balance = 0,
			};

			_context.Accounts.Add(account);
			_context.SaveChanges();

			return "Аккаунт успешно создан!";
		}

		public Account GetAccount(uint accountId)
		{
			return _context.Accounts.FirstOrDefault(a => a.Id == accountId);
		}

		public decimal GetBalance(uint accountId)
		{
			return _context.Accounts.FirstOrDefault(a => a.Id == accountId).Balance;
		}

		public ICollection<Transaction> GetTransactions(uint accountId)
		{
			return _context.Transactions.Where(t => t.RecipientId == accountId || t.SenderId == accountId).ToList();
		}
	}
}