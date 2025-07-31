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
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        public EfMenuTableDal(WebContext context) : base(context)
        {
        }

        public int MenuTableCount()
        {
            using var context = new WebContext();
            return context.MenuTables.Count();
        }
        public int NumberOfEmptyTables()
        {
            using var context = new WebContext();
            return context.Orders.Count(x => x.Description == "Hesap Kapatildi");
        }
    }

}
