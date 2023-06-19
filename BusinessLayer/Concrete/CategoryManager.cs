using BusinessLayer.Abstract;
using DataAccsesLayer.Abstract;
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
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Create(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);  
        }

        public List<Category> GetAll()
        {
            return _categoryDal.List();   
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x=>x.CategoryID==id);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
