using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryService _categoryService;

        public CategoryManager(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void Create(Category category)
        {
            _categoryService.Create(category);
        }

        public void Delete(Category category)
        {
            _categoryService.Delete(category);  
        }

        public List<Category> GetAll()
        {
            return _categoryService.GetAll();   
        }

        public Category GetById(int id)
        {
            return _categoryService.GetById(id);
        }

        public void Update(Category category)
        {
            _categoryService.Update(category);
        }
    }
}
