using System.Collections.Generic;

namespace Students.API.Models
{
    public class Group
    {
        /// <summary>
        /// Это поле системное, изменение данного поля не допускается.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя группы. (обязательное, максимальная длина 25 символов)
        /// </summary>
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}
