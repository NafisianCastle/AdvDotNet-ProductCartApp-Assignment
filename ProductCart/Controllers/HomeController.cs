using System.Linq;
using System.Web.Mvc;
using ProductCart.Models.Database;

namespace ProductCart.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new product_taskEntities();
            var data = db.Products.ToList();
            return View(data);
        }

        public ActionResult AddToCart()
        {
            if (Session["cart"]== null)
            {
                
            }
            else
            {

            }
            return RedirectToAction("Index");
        }

        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}