using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();

        Category GetById(int Id);

        void Add(Category category);
        void Update(Category cacategoryr);
        void Delete(Category category);

    }
}
