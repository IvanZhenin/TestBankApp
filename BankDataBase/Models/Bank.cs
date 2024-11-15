namespace BankDataBase.Models
{
	public class Bank
	{
		public required uint Id { get; set; }
		public required string BankName { get; set; }
		public ICollection<Account> Accounts { get; set; } = [];
	}
}