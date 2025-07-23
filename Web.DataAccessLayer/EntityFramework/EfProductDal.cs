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
    }
}
