namespace BankDataBase.Models
{
	public class Bank
	{
		public uint Id { get; set; }
		public string BankName { get; set; } = "";
		public ICollection<Account> Accounts { get; set; } = [];
	}
}