using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Singularity.Controllers
{
    public class UserInformationController : Controller
    {
        // GET: UserInformation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult User()
        {
            var check = Session["Email"];
            if (check != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "LogIn");
            }
        }

        public ActionResult Recovery()
        {
            return View();
        }

    }
}