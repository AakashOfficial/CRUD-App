using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUD_App.Models
{
    public class UserModel
    {
        [Key]
        public string id { get; set; }

        [Required(ErrorMessage = "Please Enter Username to Register")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Email to Register")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password to Register")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        // [Required(ErrorMessage = "Please Enter Address to Register")]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}