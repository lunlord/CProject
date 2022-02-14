using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace CProject.Models
{
    public class User : IdentityUser
    {
        //[Display(Name = "Phone number")]
        //[DataType(DataType.PhoneNumber)]
        //[Required(ErrorMessage = "You need to enter Phone number")]
        //public String PhoneNumber { get; set; }

        [Display(Name = "Adress")]
        [Required(ErrorMessage = "You need to enter Adress")]
        public String Adress { get; set; }

        public String UserRole { get; set; }
    }
}