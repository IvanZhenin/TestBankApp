using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BankDtoModels.Interfaces;

namespace BankDtoModels
{
    public class AccountDto : IDto
	{
		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Номер аккаунта")]
		public uint Id { get; set; }

		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Номер банка")]
		public uint BankId { get; set; }

		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Баланс аккаунта")]
		public decimal Balance { get; set; }

		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Имя аккаунта")]
		public string AccountName { get; set; } = "";

		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Дата создания аккаунта")]
		public DateTime CreationDate { get; set; }
	}
}