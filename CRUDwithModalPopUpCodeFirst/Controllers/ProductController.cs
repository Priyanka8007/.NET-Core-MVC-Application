
using CRUDwithModalPopUpCodeFirst.DAL;
using CRUDwithModalPopUpCodeFirst.Models.DBEntities;
using Microsoft.AspNetCore.Mvc;

namespace CRUDwithModalPopUpCodeFirst.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyAppDbContext _context;

        public ProductController(MyAppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetProducts()
        {
            var products = _context.Products.ToList();
            return Json(products);
        }

        [HttpPost]
		public JsonResult Insert(Product product)
		{
            if(ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Json("Product details saved");
            }
           
				return Json("Model validation failed");
			
		}

        [HttpGet]
        public JsonResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            return Json(product);
        }

        [HttpPost]
        public JsonResult Update(Product model)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Update(model);
                _context.SaveChanges();
                return Json("product details updated");
            }
			return Json("Model validation failed");
		}

        public JsonResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if(product!=null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return Json("product details deleted");
            }
			return Json($"product details  not found with id {id}");
		}
	}

}


   