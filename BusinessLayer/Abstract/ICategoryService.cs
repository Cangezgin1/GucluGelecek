﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        void Create(Category category);
        void Delete(Category category);
        void Update(Category category);

        Category GetById(int id);
        List<Category> GetAll();
    }
}
