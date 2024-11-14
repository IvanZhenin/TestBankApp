using BankDataBase.Models;

namespace BankDataBase.Repositories.Interfaces
{
	public interface ITransactionRepository
	{
		string CreateNewTransaction(uint senderId, uint recipientId, decimal amount);
		bool TransactionExists(Guid transactionId);
	} 
}