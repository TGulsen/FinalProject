using Business.Abstract;
using DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        //Constructor Injection ile bağlılığımızı yaparız.
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            //iş kodları
            return _categoryDal.GetAll();

        }

        public Category GetById(int categoryId)
        {
            //iş kodları
            // select * from Categories Where categoryId=? 
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }



    }
}
