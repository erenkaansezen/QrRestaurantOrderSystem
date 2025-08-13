using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccessLayer.Abstract;
using Web.DataAccessLayer.Concrete;
using Web.DataAccessLayer.Repositories;
using Web.EntityLayer.Entities;

namespace Web.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(WebContext context) : base(context)
        {
        }
        public List<Product> GetProductsWithCategories()
        {
            var context = new WebContext();
            var values = context.Products
                .Include(p => p.Category)
                .ToList();

            return values;
        }

        public int ProductCount()
        {
            using var context = new WebContext();
            return context.Products.Count();
        }

        public int ProductCountByCategoryDrink()
        {
            using var context = new WebContext();
            return context.Products.Count(x=> x.CategoryId==(context.Categories.Where(y=>y.CategoryName == "Içecekler").Select(y => y.CategoryID).FirstOrDefault()));
        }

        public int ProductCountByCategoryHamburger()
        {
            using var context = new WebContext();
            return context.Products.Count(x => x.CategoryId == (context.Categories.Where(y => y.CategoryName == "Burgerler").Select(y => y.CategoryID).FirstOrDefault()));
        }

        public string ProductNameByPriceByMax()
        {
            using var context = new WebContext();
            return context.Products
                .OrderByDescending(x => x.Price)
                .Select(x => x.ProductName)
                .FirstOrDefault();
        }

        public string ProductNameByPriceByMin()
        {
            using var context = new WebContext();
            return context.Products
                .OrderBy(x => x.Price)
                .Select(x => x.ProductName)
                .FirstOrDefault();
        }

        public decimal ProductPriceAvg()
        {
            using var context = new WebContext();
            return context.Products
                .Average(x => x.Price);
        }

        public decimal ProductAvgPriceByHamburger()
        {
            using var context = new WebContext();
            return context.Products.Where(x => x.CategoryId == (context.Categories.Where(y => y.CategoryName == "Burgerler").Select(y => y.CategoryID).FirstOrDefault()))
                .Average(x => x.Price);
        }

        public List<Product> GetLastProduct9()
        {
            using var context = new WebContext();
            return context.Products                
                .Take(9)
                .ToList();
        }
    }
}
