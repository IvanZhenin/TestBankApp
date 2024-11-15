using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BankDtoModels.Interfaces;

namespace BankDtoModels
{
	public class TransactionDto : NewTransactionDto
	{
		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Номер транзакции")]
		public required Guid Id { get; set; }

		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Дата создания транзакции")]
		public required DateTime DateCreate { get; set; }
	}
}