using System.Collections.Generic;
using DataAccess.EF;

namespace Students.API.Models
{
    public class Student : IEntity
    {
        /// <summary>
        /// Это поле системное, изменение данного поля не допускается.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Пол (обязательное поле)
        /// https://en.wikipedia.org/wiki/ISO/IEC_5218
        /// </summary>
        public byte Sex { get; set; }
        /// <summary>
        /// Фамилия (обязательное, максимальная длина 40 символов)
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Имя (обязательное, максимальная длина 40 символов)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Отчество ( не обязательное, максимальная длина 60 символов)
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Уникальный идентификатор студента (not required, должен быть уникальным в рамках всех студентов,
        /// минимальная длина 6 символов, максимальная длина 16). 
        /// Опциональный, например мы хотим задать для студента позывной,
        /// но не хотим чтобы два студента были с одинаковыми позывными
        /// </summary>
        public string Slug { get; set; }
        /// <summary>
        /// Группы студента
        /// </summary>
        public IList<StudentGroup> StudentGroups { get; set; }
    }
}
