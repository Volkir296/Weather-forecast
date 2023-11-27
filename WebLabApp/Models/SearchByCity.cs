using System.ComponentModel.DataAnnotations;

namespace WebLabApp.Models
{
    public class SearchByCity
    {
        [Required(ErrorMessage = "'Пусто' в назании города!")]
        [Display(Name = "Название города")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Невернный ввод, Длинна названия города от 2 до 20 символов")]
        public string CityName { get; set; }

    }
}
