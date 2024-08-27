using ECommerce.Business.Abstract;
using ECommerce.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: ProductController
        public async Task<ActionResult> Index(int page = 1, int category = 0)
        {
            var items=await _productService.GetAllByCategoryAsync(category);
            int pageSize = 10;

            var model = new ProductListViewModel
            {
                Products=items.Skip((page-1)*pageSize).Take(pageSize).ToList(),
                PageSize=pageSize,
                CurrentCategory=category,
                CurrentPage=page,
                PageCount=(int)Math.Ceiling(items.Count/(double)pageSize),
                IsAdmin=User.IsInRole("Admin")
            };

            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Add()
        {
            var model = new ProductAddViewModel();
            return View(model);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductAddViewModel model)
        {
            try
            {
                if (ModelState.IsValid && model.Product != null)
                {
                    _productService.AddAsync(model.Product);
                    TempData.Add("message", "Your Product was successfully added");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id, int page=1,int cat = 0)
        {
            _productService.DeleteAsync(id); // <-- request atilir ama silmir product
            TempData.Add("message", "Your Product was successfully deleted");
            return RedirectToAction("Index",new {page,cat});
        }
    }
}
