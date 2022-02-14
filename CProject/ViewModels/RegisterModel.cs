using System;
using System.ComponentModel.DataAnnotations;

namespace CProject.ViewModels
{
    public class RegisterModel
    {
        [Display(Name = "Password")]
        [Required(ErrorMessage = "You need to enter Password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "You need to enter Phone number")]
        public String PhoneNumber { get; set; }

        [Display(Name = "Adress")]
        [Required(ErrorMessage = "You need to enter Adress")]
        public String Adress { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You need to enter Email")]
        public String Email { get; set; }

        public String UserRole { get; set; }
    }
}