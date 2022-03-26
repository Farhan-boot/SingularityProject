using Singularity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Singularity.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Auth(LogIn logInfo)
        {
            string error = string.Empty;

            if (IsValidLogIn(logInfo, out error))
            {
                using (SingularityDbContext db = new SingularityDbContext())
                {
                    var db_logInfo = db.HR_User.Include(x=>x.HR_Role).SingleOrDefault(x => x.Email == logInfo.Email && x.Password == logInfo.Password);

                    if (db_logInfo != null)
                    {
                        Session["Email"] = db_logInfo.Email;
                        Session["Password"] = db_logInfo.Password;
                        Session["RoleId"] = db_logInfo.RoleId;
                        Session["RoleName"] = db_logInfo.HR_Role.Name;
                        return Json(new { status = true }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { status = false }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            else
            {
                return Json(new { status = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult LogOut()
        {
            Session["Email"] = null;
            Session["Password"] = null;
            Session["RoleId"] = null;
            Session["RoleName"] = null;
            return Json(new { status = true }, JsonRequestBehavior.AllowGet);
        }


        private bool IsValidLogIn(LogIn logInfo, out string error)
        {
            error = "";
            if (logInfo.Email == null || logInfo.Email == "")
            {
                error += "Email is not valid.";
                return false;
            }
            if (logInfo.Password == null || logInfo.Password == "")
            {
                error += "Password is not valid.";
                return false;
            }
            return true;
        }
    }


    public class LogIn
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
    }
}