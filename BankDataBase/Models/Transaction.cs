namespace BankDataBase.Models
{
	public class Transaction
	{
		public Guid Id { get; set; }
		public uint SenderId { get; set; }
		public uint RecipientId { get; set; }
		public decimal TransactionAmount { get; set; }
		public DateTime DateCreate { get; set; }
		public Account SenderAccount { get; set; }
		public Account RecipientAccount { get; set; }
	}
}