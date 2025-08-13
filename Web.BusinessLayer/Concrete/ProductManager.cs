using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.BusinessLayer.Abstract;
using Web.DataAccessLayer.Abstract;
using Web.EntityLayer.Entities;

namespace Web.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> TGetAll()
        {
            return _productDal.GetAll();
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> TGetLastProduct9()
        {
            return _productDal.GetLastProduct9();
        }

        public List<Product> TGetProductsWithCategories()
        {
            return _productDal.GetProductsWithCategories();
        }

        public decimal TProductAvgPriceByHamburger()
        {
            return _productDal.ProductAvgPriceByHamburger();
        }

        public int TProductCount()
        {
            return _productDal.ProductCount();
        }

        public int TProductCountByCategoryDrink()
        {
            return _productDal.ProductCountByCategoryDrink();
        }

        public int TProductCountByCategoryHamburger()
        {
            return _productDal.ProductCountByCategoryHamburger();
        }

        public string TProductNameByPriceByMax()
        {
            return _productDal.ProductNameByPriceByMax();
        }

        public string TProductNameByPriceByMin()
        {
            return _productDal.ProductNameByPriceByMin();
        }

        public decimal TProductPriceAvg()
        {
            return _productDal.ProductPriceAvg();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
