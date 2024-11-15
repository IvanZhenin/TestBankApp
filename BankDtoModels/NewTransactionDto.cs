using BankDtoModels.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BankDtoModels
{
	public class NewTransactionDto : IDto
	{
		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Номер отправителя")]
		public required uint SenderId { get; set; }

		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Номер получателя")]
		public required uint RecipientId { get; set; }

		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Сумма транзакции")]
		public required decimal TransactionAmount { get; set; }
	}
}