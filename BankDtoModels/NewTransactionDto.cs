using BankDtoModels.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BankDtoModels
{
	public class NewTransactionDto : IDto
	{
		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Номер отправителя")]
		public uint SenderId { get; set; }

		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Номер получателя")]
		public uint RecipientId { get; set; }

		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Сумма транзакции")]
		public decimal TransactionAmount { get; set; }
	}
}