using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web.DataAccessLayer.Abstract;
using Web.DataAccessLayer.Concrete;
using Web.DataAccessLayer.Repositories;
using Web.EntityLayer.Entities;

namespace Web.DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(WebContext context) : base(context)
        {
        }
        public List<Basket> GetBasketByTableNumber(int id)
        {
            using var context = new WebContext();
            var result = context.Baskets
                .Where(b => b.MenuTableId == id)
                .Include(y=>y.Product)
                .ToList();
            return result;
        }
    }
}
