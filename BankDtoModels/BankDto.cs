using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BankDtoModels.Interfaces;

namespace BankDtoModels
{
    public class BankDto : IDto
	{
		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Номер банка")]
		public uint Id { get; set; }

		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		[DisplayName("Название банка")]
		public string BankName { get; set; } = "";
	}
}
