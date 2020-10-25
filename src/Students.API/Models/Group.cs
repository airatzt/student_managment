using DataAccess.EF;
using System.Collections.Generic;

namespace Students.API.Models
{
    public class Group : IEntity
    {
        /// <summary>
        /// Это поле системное, изменение данного поля не допускается.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя группы. (обязательное, максимальная длина 25 символов)
        /// </summary>
        public string Name { get; set; }
        public IList<StudentGroup> StudentGroups { get; set; }
    }
}
