using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        //Kategoriyle ilgili,dış dünyaya neyi servis etmek istiyorsam o operasyonları yazıyorum.

        List<Category> GetAll();
        Category GetById(int categoryId);
        Category GetBy(int categoryId);

    }
}
