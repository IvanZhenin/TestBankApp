namespace BankDataBase.Models
{
	public class Account
	{
		public uint Id { get; set; }
		public uint BankId { get; set; }
		public decimal Balance { get; set; }
		public string AccountName { get; set; } = "";
		public DateTime CreationDate { get; set; }
		public Bank Bank { get; set; }
		public ICollection<Transaction> SentTransactions { get; set; } = [];
		public ICollection<Transaction> ReceivedTransactions { get; set; } = [];
	}
}