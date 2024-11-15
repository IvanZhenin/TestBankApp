using BankDtoModels.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BankDtoModels
{
	public class NewAccountDto : IDto
	{
		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Имя аккаунта")]
		public string AccountName { get; set; } = "";

		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Номер банка")]
		public uint BankId { get; set; }
	}
}