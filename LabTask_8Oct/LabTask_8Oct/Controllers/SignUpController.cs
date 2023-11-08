using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using LabTask_8Oct.Models;

namespace LabTask_8Oct.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
       
        public ActionResult SignIn(SignIn S)
        {
            return View(S);
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignUp s)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("SignIn");
            }
            return View(s);
        }
    }
}