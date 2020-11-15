using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Students.API.ViewModels
{
    public class CreateStudentViewModel
    {
        [Required(ErrorMessage = "Не указан пол")]
        [Range(1, 2)]
        public byte Sex { get; set; }
        [Required(ErrorMessage = "Не указана фамилия ")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Длина фамилии должна быть от 1 до 40 символов")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Не указано имя ")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Длина имени должна быть от 1 до 40 символов")]
        public string Name { get; set; }
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Длина отчества должна быть от 1 до 60 символов")]
        public string Patronymic { get; set; }
        [StringLength(16, MinimumLength = 1, ErrorMessage = "Длина уникальный идентификатор студента  должна быть от 1 до 16 символов")]
        public string Slug { get; set; }
        [Remote(action: "VerifyGroups", controller: "Groups")]
        public IList<int> GroupsIds { get; set; }
    }
}
