using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger42915.Models;
using System.Diagnostics;

namespace ZeroHunger42915.Controllers
{
    public class RestaurantController : Controller
    {
        private ZeroHungerContext db = new ZeroHungerContext();

        // Index view for a restaurant to view and create food collection requests
        public ActionResult Index()
        {
            var foodRequests = db.FoodCollectionRequests.ToList();
            return View(foodRequests);
        }

        //[httppost]
        //public actionresult createfoodrequest(foodcollectionrequest request)
        //{
        //    if (modelstate.isvalid)
        //    {
        //        // proceed to save the data if the model is valid
        //        db.foodcollectionrequests.add(request);
        //        db.savechanges(); // save the changes to the database
        //        return redirecttoaction("index");
        //    }
        //    return view();
        //}
        [HttpPost]
        public ActionResult CreateFoodRequest(FoodCollectionRequest request)
        {
            if (ModelState.IsValid)
            {
                request.IsAssigned = false; 
                request.IsCompleted = false; 

                using (var db = new ZeroHungerContext())
                {
                    db.FoodCollectionRequests.Add(request);

                    db.SaveChanges();

                    //try
                    //{
                    //    db.SaveChanges();
                    //}
                    //catch(DbEntityValidationException e)
                    //{
                    //    Console.WriteLine(e);
                    //}
                }

                return RedirectToAction("Index", "Restaurant");
            }

            return View(request);
        }


        [HttpPost]
        public ActionResult Search(string searchTerm, int requestId = 0)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var foodRequests = db.FoodCollectionRequests
                    .Where(r => r.RestaurantName.Contains(searchTerm))
                    .ToList();
                ViewBag.IsSearchPerformed = true;
                //Console.WriteLine(foodRequests);
                return View("Index", foodRequests);
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int requestId)
        {
            using (var db = new ZeroHungerContext())
            {
                var request = db.FoodCollectionRequests.FirstOrDefault(r => r.RequestID == requestId);

                if (request != null)
                {
                    db.FoodCollectionRequests.Remove(request);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

               
                return RedirectToAction("Index");
            }
        }
    }
}
