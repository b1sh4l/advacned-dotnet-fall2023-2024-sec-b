using System;
using System.Linq;
using System.Web.Mvc;
using ZeroHunger42915.Models;
using System.Data.Entity;
using System.Web.Security;

namespace ZeroHunger42915.Controllers
{
    public class EmployeeController : Controller
    {
        private ZeroHungerContext db = new ZeroHungerContext();

        // GET: Employee

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(int employeeId, string employeeName)
        {
            // Check employee credentials against a database or some other authentication logic

            var employee = db.Employees.FirstOrDefault(e => e.EmployeeID == employeeId && e.FullName == employeeName);

            if (employee != null)
            {
                // If credentials are valid, redirect to the EmployeeTasks view
                return RedirectToAction("EmployeeTasks", new { employeeId });
            }
            else
            {
                // If credentials are invalid, return to the login page with an error
                ModelState.AddModelError("", "Invalid employee ID or name.");
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Employee"); // Redirect to the login page or any desired page after logout
        }

        public ActionResult EmployeeTasks(int employeeId = 2)
        {
            var tasks = db.AssignedTasks.Where(t => t.EmployeeID == employeeId).ToList();
            return View("AssignedTasks", tasks);
        }

        public ActionResult EmployeeDetails(int employeeId)
        {
            var employee = db.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            return View(employee);
        }

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
