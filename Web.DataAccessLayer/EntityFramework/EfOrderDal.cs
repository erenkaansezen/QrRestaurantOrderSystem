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
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(WebContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new WebContext();
            return context.Orders.Count(x => x.Description == "Müşteri Masada");
        }

        public decimal LastOrderPrice()
        {
            using var context = new WebContext();
            return context.Orders
                .OrderByDescending(x => x.OrderId)
                .Take(1)
                .Select(y => y.TotalPrice)
                .FirstOrDefault();
        }

        public decimal TodayTotalPrice()
        {
            using var context = new WebContext();
            return context.Orders
                .Where(x => x.OrderDate == DateTime.Parse(DateTime.Now.ToShortDateString()))
                .Sum(y => y.TotalPrice);
        }

        public int TotalOrderCount()
        {
            using var context = new WebContext();
            return context.Orders.Count();  
        }
    }
}
