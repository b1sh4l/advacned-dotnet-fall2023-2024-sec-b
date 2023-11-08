using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger42915.DTO
{
    public class AssignedTaskDTO
    {
        [Required(ErrorMessage = "Task ID is required")]
        public int TaskID { get; set; }

        [Required(ErrorMessage = "Employee ID is required")]
        public int EmployeeID { get; set; }
    }
}