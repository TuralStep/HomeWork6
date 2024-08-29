using ECommerce.Business.Abstract;
using ECommerce.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce.WebUI.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public IActionResult Delete(int id)
        {
            //TempData.Add("message", String.Format("Category id:!{0}!", id));
            //return RedirectToAction("Index", "Product");
            _categoryService.DeleteById(id);
            TempData.Add("message", "Category was successfully deleted");
            return RedirectToAction("Index","Product");
        }

        public IActionResult Add(CategoryListViewModel clvm)
        {
            //TempData.Add("message", String.Format("Category name:!{0}!", clvm.AddingCategory));
            //return RedirectToAction("Index", "Product");
            _categoryService.Add(clvm.AddingCategory);
            TempData.Add("message", String.Format("New category({0}) Product was successfully added",clvm.AddingCategory));
            return RedirectToAction("Index", "Product");
        }

    }
}
