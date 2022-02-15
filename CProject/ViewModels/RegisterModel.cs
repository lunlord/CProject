using System;
using System.ComponentModel.DataAnnotations;

namespace CProject.ViewModels
{
    public class RegisterModel
    {
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Пароль должен состоять из минимум 8 символов")]
        public String Password { get; set; }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Введите номер телефона")]
        [RegularExpression(@"[7]{1}[0-9]{3}[0-9]{3}[0-9]{4}",
                   ErrorMessage = "Формат номера неверен. Номер должен начинаться с 7 и содержать всего 11 цифр. (пример телефонного номера: 79991235544)")]
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