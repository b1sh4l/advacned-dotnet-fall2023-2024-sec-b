using System;
using System.Linq;
using System.Web.Mvc;
using ZeroHunger42915.Models;
using System.Data.Entity;
using System.Web.Security;
using ZeroHunger42915.ViewModel;

namespace ZeroHunger42915.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ZeroHungerContext db = new ZeroHungerContext();

        // GET: Employee

        public ActionResult Index()
        {

            return View();
        }

        private bool CheckCredentials(int employeeId, string employeeName)
        {
            var employee = db.Employees.FirstOrDefault(e => e.EmployeeID == employeeId && e.FullName == employeeName);
            return employee != null;
        }

        [HttpPost]
        public ActionResult Index(int EmployeeID, string FullName)
        {
            

            var employee = db.Employees.FirstOrDefault(e => e.EmployeeID == EmployeeID && e.FullName == FullName);

            if (employee != null)
            {
                if (CheckCredentials(employee.EmployeeID, employee.FullName))
                {
                    return RedirectToAction("EmployeeTasks", new { employeeId = employee.EmployeeID });
                }
                else
                {
                    ModelState.AddModelError("EmployeeID", "Invalid employee ID or name.");
                    ModelState.AddModelError("FullName", "Invalid employee ID or name.");
                }
            }
            else
            {
                ModelState.AddModelError("EmployeeID", "Employee not found.");
            }

            return View();
        }

        //    if (employee != null)
        //    {

        //        return RedirectToAction("EmployeeTasks", new { employeeId });
        //    }
        //    else
        //    {

        //        ModelState.AddModelError("", "Invalid employee ID or name.");
        //        return View();
        //    }
        //}


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Employee"); 
        }

        public ActionResult _AssignedTasks(int employeeId)
        {
            var tasks = db.AssignedTasks.Where(t => t.EmployeeID == employeeId).ToList();
            return View("_AssignedTasks", tasks);
        }

        public ActionResult _EmployeeDetails(int employeeId)
        {
            var employee = db.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            return View("_EmployeeDetails", employee);
        }

        public ActionResult EmployeeTasks(int employeeId)
        {
            var employee = db.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            var tasks = db.AssignedTasks.Where(t => t.EmployeeID == employeeId).ToList();

            var viewModel = new EmployeeTasksViewModel
            {
                Employee = employee,
                AssignedTasks = tasks
            };

            return View(viewModel);
        }

        //[HttpPost]
        //public ActionResult EmployeeDetails(string employeeName, int employeeId)
        //{
        //    if (employeeId != 0)
        //    {
        //        var empDetails = db.Employees
        //            .Where(r => r.EmployeeID == employeeId)
        //            .ToList();
        //        ViewBag.IsSearchPerformed = true;
        //        //Console.WriteLine(foodRequests);
        //        return View("Index", empDetails);
        //    }

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult UpdateAssignedTaskCompletion(int taskId)
        {
            var assignedTask = db.AssignedTasks.FirstOrDefault(t => t.TaskID == taskId);

            if (assignedTask != null)
            {
                assignedTask.CompletedDateTime = DateTime.Now;
                db.SaveChanges();

                var foodRequest = db.FoodCollectionRequests.FirstOrDefault(fr => fr.RequestID == assignedTask.RequestID);

                if (foodRequest != null)
                {
                    foodRequest.IsCompleted = true;
                    db.SaveChanges();
                }
            }

            return RedirectToAction("EmployeeTasks", new { employeeId = assignedTask.EmployeeID });
        }
    }
}
