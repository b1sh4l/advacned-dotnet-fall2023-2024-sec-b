using System;
using System.Linq;
using System.Web.Mvc;
using ZeroHunger42915.Models;
using ZeroHunger42915.DTO;

namespace ZeroHunger42915.Controllers
{
    public class RestaurantController : Controller
    {
        private ZeroHungerContext db = new ZeroHungerContext();

        public ActionResult Index()
        {
            var foodRequests = db.FoodCollectionRequests.ToList();
            return View(foodRequests);
        }

        [HttpPost]
        public ActionResult CreateFoodRequest(FoodCollectionRequestDTO request)
        {
            if (ModelState.IsValid)
            {
                var newRequest = new FoodCollectionRequest
                {
                    RestaurantName = request.RestaurantName,
                    MaxPreservationTime = request.MaxPreservationTime,
                    IsAssigned = request.IsAssigned,
                    IsCompleted = request.IsCompleted
                };

                using (var db = new ZeroHungerContext())
                {
                    db.FoodCollectionRequests.Add(newRequest);
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "Restaurant");
            }

            return View(request);
        }

        [HttpPost]
        public ActionResult Search(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var foodRequests = db.FoodCollectionRequests
                    .Where(r => r.RestaurantName.Contains(searchTerm))
                    .ToList();

                ViewBag.IsSearchPerformed = true;
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
                }

                return RedirectToAction("Index");
            }
        }
    }
}
