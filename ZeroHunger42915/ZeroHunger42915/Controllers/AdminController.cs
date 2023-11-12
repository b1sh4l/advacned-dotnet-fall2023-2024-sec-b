using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger42915.DTO;
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

        public ActionResult _Employees()
        {
            var employees = db.Employees.ToList();
            return PartialView(employees);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult _AddEmployee(Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Employees.Add(employee);
        //        db.SaveChanges();

        //        return RedirectToAction("FoodRequests");
        //    }

        //    return PartialView("_AddEmployee", employee);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _AddEmployee(EmployeeDTO employeeDTO)
        {
            if (ModelState.IsValid)
            {

                var employee = new Employee
                {
                    EmployeeID = employeeDTO.EmployeeID,
                    FullName = employeeDTO.FullName,
                    MobileNo = employeeDTO.MobileNo,

                };


                db.Employees.Add(employee);
                db.SaveChanges();

                return RedirectToAction("FoodRequests");
            }


            return PartialView("_AddEmployee", employeeDTO);
        }
    }
}
