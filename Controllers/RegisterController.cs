using Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manager.Controllers
{
    public class RegisterController:Controller
    {
        public ActionResult Login(Company model)
        {
           
            return View(model);
        }

        public ActionResult Agency(Company company)
        {
            return View("Agency");
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GetCompany(Company model)
        {
            using (OrganisationEntities db = new OrganisationEntities())
            {
                var company = db.Companies.Where(x => x.CompanyName == model.CompanyName).FirstOrDefault();
                if (company != null)
                {
                    return RedirectToAction("Login", company);
                }
            }
            return null;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UserLogin(user users)
        {
            ManagerEntities db = new ManagerEntities();
            var user = db.users.Where(x => x.email == users.email).FirstOrDefault();
                if (user != null)
                {
                    Session["username"] = user.username;
                    return RedirectToAction("Index","Home",user);
                }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Logout(user users)
        {
                Session["username"] = "";
                return RedirectToAction("Agency", "Register");
        }
        
    }

    
}