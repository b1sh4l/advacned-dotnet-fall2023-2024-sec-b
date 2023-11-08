using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHunger42915.Models;

namespace ZeroHunger42915.ViewModel
{
    public class EmployeeTasksViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<AssignedTask> AssignedTasks { get; set; }
    }
}