using BankDataBase.Models;

namespace BankDataBase.Repositories.Interfaces
{
	public interface ITransactionRepository
	{
		Task<string> CreateNewTransaction(uint senderId, uint recipientId, decimal amount);
		Task<bool> TransactionExists(Guid transactionId);
	} 
}