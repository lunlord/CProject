using System;
using System.ComponentModel.DataAnnotations;

namespace CProject.ViewModels
{
    public class EditUserModel
    {
        public string Id { get; set; }

        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11)]
        [Required(ErrorMessage = "You need to enter Phone number")]
        public String PhoneNumber { get; set; }

        [Display(Name = "Adress")]
        [Required(ErrorMessage = "You need to enter Adress")]
        public String Adress { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You need to enter Email")]
        public String Email { get; set; }

        public String Role { get; set; }
    }
}