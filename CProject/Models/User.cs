using System;
using System.ComponentModel.DataAnnotations;

namespace CProject.Models
{
    public class User
    {
        [Display(Name = "User ID")]
        [Required(ErrorMessage = "You need to enter User ID")]
        public int UserId { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "You need to enter Login")]
        public String Login { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You need to enter Password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "You need to enter Phone number")]
        public String Phone_number { get; set; }

        [Display(Name = "Adress")]
        [Required(ErrorMessage = "You need to enter Adress")]
        public String Adress { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You need to enter Email")]
        public String Email { get; set; }
    }
}

