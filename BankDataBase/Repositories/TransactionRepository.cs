using BankDataBase.Data;
using BankDataBase.Models;
using BankDataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankDataBase.Repositories
{
	public class TransactionRepository : ITransactionRepository
	{
		private readonly BankDataContext _context;
		public TransactionRepository(BankDataContext context)
		{
			_context = context;
		}

		public async Task<string> CreateNewTransaction(uint senderId, uint recipientId, decimal amount)
		{
			if (senderId == recipientId)
				return "Ошибка: неверно указаны данные счетов!";

			if (amount <= 0)
				return "Ошибка: неверно указана сумма транзакции!";

			using (var transact = await _context.Database.BeginTransactionAsync())
			{
				try
				{
					var sender = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == senderId);
					var recipient = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == recipientId);

					if (sender == null || recipient == null)
						return "Ошибка: неправильно указаны данные счетов!";

					if (sender.Balance < amount)
						return "Ошибка: недостаточно средств на счету отправителя!";

					var transaction = new Transaction()
					{
						Id = Guid.NewGuid(),
						SenderId = senderId,
						RecipientId = recipientId,
						DateCreate = DateTime.Now,
						TransactionAmount = amount,
					};

					sender.Balance -= amount;
					recipient.Balance += amount;

					_context.Transactions.Add(transaction);
					await _context.SaveChangesAsync();

					await transact.CommitAsync();
					return "Транзакция успешно создана!";
				}
				catch (Exception ex)
				{
					await transact.RollbackAsync();
					return $"Произошла критическая ошибка!\n {ex.ToString()}";
				}
			}
		}

		public async Task<bool> TransactionExists(Guid transactionId)
		{
			var checkTransaction = await _context.Transactions.AnyAsync(t => t.Id == transactionId);
			return checkTransaction;
		}
	}
}