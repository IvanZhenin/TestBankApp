﻿using BankDataBase.Data;
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
				return "Не удалось создать аккаунт, необходимо указать имя!";

			if (!await _context.Banks.AnyAsync(b => b.Id == bankId))
				return "Не удалось создать аккаунт, неверно указан номер банка!";

			var accountList = await _context.Accounts.AsNoTracking()
				.OrderBy(a => a.Id).Select(a => a.Id).ToListAsync();

			var account = new Account()
			{
				Id = UniqueIdProvider.GetNewUintId(accountList),
				AccountName = accountName,
				BankId = bankId,
				CreationDate = DateTime.Now,
				Balance = 0,
			};

			_context.Accounts.Add(account);
			await _context.SaveChangesAsync();

			return "Аккаунт успешно создан!";
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