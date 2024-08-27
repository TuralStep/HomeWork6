using ECommerce.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public IActionResult Delete(int id)
        {
            _categoryService.DeleteById(id);
            return RedirectToAction("Index","Product");
        }

        public IActionResult Add(string name)
        {
            _categoryService.Add(name);
            return RedirectToAction("Index", "Product");
        }

    }
}
