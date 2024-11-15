using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BankDtoModels.Interfaces;

namespace BankDtoModels
{
	public class TransactionDto : IDto
	{
		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Номер транзакции")]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Номер отправителя")]
		public uint SenderId { get; set; }

		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Номер получателя")]
		public uint RecipientId { get; set; }

		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Сумма транзакции")]
		public decimal TransactionAmount { get; set; }

		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Дата создания транзакции")]
		public DateTime DateCreate { get; set; }
	}
}