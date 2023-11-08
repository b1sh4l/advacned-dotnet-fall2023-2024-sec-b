using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger42915.DTO
{
    public class EmployeeDTO
    {
        [Required(ErrorMessage = "Employee ID is required")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        public string FullName { get; set; }
    }
}