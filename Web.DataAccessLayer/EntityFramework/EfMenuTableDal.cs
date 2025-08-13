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
        public int ActiveMenuTableCount()
        {
            using var context = new WebContext();
            return context.MenuTables.Count(x => x.Status == true);
        }
        public int NumberOfEmptyTables()
        {
            using var context = new WebContext();
            return context.MenuTables.Count(x => x.Status == false);
        }

        public void ChangeTableStatusTrue(int id)
        {
            using var context = new WebContext();
            var table = context.MenuTables.Find(id);
            table.Status = true;
            context.SaveChanges();
            

        }

        public void ChangeTableStatusFalse(int id)
        {
            using var context = new WebContext();
            var table = context.MenuTables.Find(id);
            table.Status = false;
            context.SaveChanges();
        }
    }

}
