using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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

        
        public ActionResult AddToCart(int id)
        {
            var db = new product_taskEntities();
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            if (Session["cart"] == null)
            {
                var productList = new List<Product> {product};
                var json = new JavaScriptSerializer().Serialize(productList);
                Session["cart"] = json;
            }
            else
            {
                var existingProds = Session["cart"].ToString();
                var products = new JavaScriptSerializer().Deserialize<List<Product>>(existingProds);
                products.Add(product);
                var json = new JavaScriptSerializer().Serialize(products);
                Session["cart"] = json;
            }
            return RedirectToAction("Index");
        }
       
        public ActionResult Checkout()
        {
            if (Session["cart"] == null) return View();
            var cartProducts = Session["cart"].ToString();
            var productList = new JavaScriptSerializer().Deserialize<List<Product>>(cartProducts);
            return View(productList);

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