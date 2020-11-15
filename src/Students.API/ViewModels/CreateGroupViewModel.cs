using System.ComponentModel.DataAnnotations;

namespace Students.API.ViewModels
{
    public class CreateGroupViewModel
    {
        /// <summary>
        /// Имя группы. (обязательное, максимальная длина 25 символов)
        /// </summary>
        [Required(ErrorMessage = "Не указано название группы")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 25 символов")]
        public string Name { get; set; }
    }
}
