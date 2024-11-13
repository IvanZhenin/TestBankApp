namespace BankDataBase.Models
{
	public class Transaction
	{
		public int Id { get; set; }
		public int SenderId { get; set; }
		public int RecipientId { get; set; }
		public decimal TransactionAmount { get; set; }
		public DateTime DateCreate { get; set; }
		public Account SenderAccount { get; set; }
		public Account RecipientAccount { get; set; }
	}
}