using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lstoneCrud.Models
{
    public class customermodel
    {
        [Display(Name = "Customer ID")]
        [Key]
        public int id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter Your Name")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Name should be more than or equal to four characters.")]
        public string name { get; set; }

        [Display(Name = "Salary")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Salary must be a numeric value.")]
        public string salary { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Enter Your EmailID")]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        public string email { get; set; }


        [Required(ErrorMessage = "You must provide a PhoneNumber")]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
       // [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        [RegularExpression(@"^(\+\d{1,4})?[-.\s]?(\d{4}[-.\s]?\d{7}|\d{10})$", ErrorMessage = "Not a valid phone number")]
        public string phoneno { get; set; }

        [Display(Name = "Home Address")]
        [Required(ErrorMessage = "Enter Your Home Address")]
        public string address { get; set; }
    }
}