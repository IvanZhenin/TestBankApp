using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BankDtoModels.Interfaces;

namespace BankDtoModels
{
    public class AccountDto : NewAccountDto
	{
		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Номер аккаунта")]
		public required uint Id { get; set; }


		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Баланс аккаунта")]
		public required decimal Balance { get; set; }


		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Дата создания аккаунта")]
		public required DateTime CreationDate { get; set; }
	}
}