using ECommerce.Business.Abstract;
using ECommerce.DataAccess.Abstraction;
using ECommerce.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(string name)
        {
            var cat = new Category()
            {
                CategoryName = name
            };
            _categoryDal.Add(cat);
        }

        public void DeleteById(int id)
        {
            var cat = _categoryDal.GetList().Result.FirstOrDefault(x => x.CategoryId == id);
            _categoryDal.Delete(cat);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryDal.GetList();
        }


    }
}
