using BankDataBase.Data;
using BankDataBase.Models;
using BankDataBase.Repositories.Interfaces;

namespace BankDataBase.Repositories
{
	public class TransactionRepository : ITransactionRepository
	{
		private readonly BankDataContext _context;
		public TransactionRepository(BankDataContext context)
		{
			_context = context;
		}

		public string CreateNewTransaction(uint senderId, uint recipientId, decimal amount)
		{
			if (senderId == recipientId)
				return "Ошибка при создании транзакции, вы не можете выбрать свой счет для перевода!";

			if (amount <= 0)
				return "Ошибка при создании транзакции, неверно указана сумма!";

			var sender = _context.Accounts.FirstOrDefault(a => a.Id == senderId);
			var recipient = _context.Accounts.FirstOrDefault(a => a.Id == recipientId);
			
			if (sender == null || recipient == null)
				return "Ошибка при создании транзакции, неправильно указаны данные счетов!";

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
			_context.SaveChanges();

			return "Транзакция успешно создана!";
		}

		public bool TransactionExists(Guid transactionId)
		{
			return _context.Transactions.Any(t => t.Id == transactionId);
		}
	}
}