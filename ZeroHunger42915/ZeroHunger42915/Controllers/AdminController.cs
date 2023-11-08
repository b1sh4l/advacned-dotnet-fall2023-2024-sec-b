using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger42915.Models;

namespace ZeroHunger42915.Controllers
{
    public class AdminController : Controller
    {
        private ZeroHungerContext db = new ZeroHungerContext();

        // GET: Admin
        public ActionResult FoodRequests()
        {
            var foodRequests = db.FoodCollectionRequests.Include("AssignedTasks.Employee").ToList();
            var employees = db.Employees.ToList();
            ViewBag.Employees = employees;
            return View(foodRequests);
        }

        [HttpPost]
        public ActionResult AssignEmployee(int requestId, int employeeId)
        {
            var assignedTask = new AssignedTask
            {
                RequestID = requestId,
                EmployeeID = employeeId,
                AssignedDateTime = DateTime.Now
            };

            db.AssignedTasks.Add(assignedTask);
            db.SaveChanges();

            var foodRequest = db.FoodCollectionRequests.Find(requestId);
            if (foodRequest != null)
            {
                foodRequest.IsAssigned = true;
                db.SaveChanges();
            }

            return RedirectToAction("FoodRequests");
        }
    }
}
