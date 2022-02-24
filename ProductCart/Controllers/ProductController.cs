using ProductCart.Models.Database;
using System.Linq;
using System.Web.Mvc;

namespace Newstask2.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            var db = new product_taskEntities();
            var data = db.Products.ToList();
            return View(data);
        }

        public ActionResult Details(int id)
        {
            var db = new product_taskEntities();
            var data = ( from p in db.Products
                                where p.Id == id 
                                select p).FirstOrDefault();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid) return View(product);
            var db = new product_taskEntities();
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var db = new product_taskEntities();
            var product = ( from u in db.Products 
                            where u.Id == id 
                            select u).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product newProduct)
        {
            try
            {
                // TODO: Add update logic here
                var db = new product_taskEntities();
                var oldProduct = (from u in db.Products
                                  where u.Id == newProduct.Id
                                  select u).FirstOrDefault();
                db.Entry(oldProduct).CurrentValues.SetValues(newProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");
            var db = new product_taskEntities();
            var product = (from u in db.Products where u.Id == id select u).FirstOrDefault();
            if (product != null) db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}