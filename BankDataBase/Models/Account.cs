namespace BankDataBase.Models
{
	public class Account
	{
		public required uint Id { get; set; }
		public required uint BankId { get; set; }
		public required decimal Balance { get; set; }
		public required string AccountName { get; set; }
		public required DateTime CreationDate { get; set; }
		public Bank? Bank { get; set; }
		public ICollection<Transaction> SentTransactions { get; set; } = [];
		public ICollection<Transaction> ReceivedTransactions { get; set; } = [];
	}
}