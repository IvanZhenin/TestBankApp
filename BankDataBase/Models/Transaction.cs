namespace BankDataBase.Models
{
	public class Transaction
	{
		public required Guid Id { get; set; }
		public required uint SenderId { get; set; }
		public required uint RecipientId { get; set; }
		public required decimal TransactionAmount { get; set; }
		public required DateTime DateCreate { get; set; }
		public Account? SenderAccount { get; set; }
		public Account? RecipientAccount { get; set; }
	}
}