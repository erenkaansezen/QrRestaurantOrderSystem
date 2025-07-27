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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(WebContext context) : base(context)
        {
        }

        public int ActiveCategoryCount()
        {
            using var context = new WebContext();
            return context.Categories.Count(c => c.Status == true);
        }

        public int CategoryCount()
        { 
            using var context = new WebContext();
            return context.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            using var context = new WebContext();
            return context.Categories.Count(c => c.Status == false);
        }
    }
}
