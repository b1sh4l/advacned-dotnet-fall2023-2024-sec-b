using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger42915.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Full Name must be between 2 and 100 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Invalid Mobile Number. It must be 11 digits.")]
        public string MobileNo { get; set; }
    }
}