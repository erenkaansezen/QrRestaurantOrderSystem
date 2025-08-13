using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
         int ProductCount();
         int ProductCountByCategoryHamburger();
         int ProductCountByCategoryDrink();
         decimal ProductPriceAvg();
         string ProductNameByPriceByMax();
         string ProductNameByPriceByMin();

        decimal ProductAvgPriceByHamburger();
        List<Product> GetLastProduct9();


    }
}
