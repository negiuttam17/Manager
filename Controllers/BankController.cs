using Manager.Models;
using System.Linq;
using System.Web.Mvc;

namespace Manager.Controllers
{
    public class BankController : Controller
    {
        public ActionResult Index()
        {
            return View("BankDetails");
        }

       
        public ActionResult BankDetails()
        {
            ViewBag.Message = "Your Bank page.";

            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveBank(BankDetail bankDetail )
        {
            using (ManagerEntities5 db = new ManagerEntities5())
            {
                db.BankDetails.Add(bankDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }
    }
}