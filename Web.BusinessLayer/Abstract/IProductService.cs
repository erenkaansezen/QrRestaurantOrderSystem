using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Web.EntityLayer.Entities;
namespace Web.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        public int TProductCount();
        int TProductCountByCategoryHamburger();
        int TProductCountByCategoryDrink();
        decimal TProductPriceAvg();
        string TProductNameByPriceByMax();
        string TProductNameByPriceByMin();
    }
}
