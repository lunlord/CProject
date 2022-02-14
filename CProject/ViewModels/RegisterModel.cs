using System;
using System.ComponentModel.DataAnnotations;

namespace CProject.ViewModels
{
    public class RegisterModel
    {
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Введите номер телефона")]
        public String PhoneNumber { get; set; }

        [Display(Name = "Адрес проживания")]
        [Required(ErrorMessage = "Введите адрес проживания")]
        public String Adress { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Введите Email")]
        public String Email { get; set; }

        public String UserRole { get; set; }
    }
}