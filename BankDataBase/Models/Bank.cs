namespace BankDataBase.Models
{
	public class Bank
	{
		public int Id { get; set; }
		public string BankName { get; set; } = "";
		public ICollection<Account> Accounts { get; set; } = [];
	}
}