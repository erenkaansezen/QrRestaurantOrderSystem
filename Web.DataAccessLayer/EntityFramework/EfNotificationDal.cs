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
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(WebContext context) : base(context)
        {
        }

        public List<Notification> GetAllNotificationsByStatusFalse()
        {
            using var context = new WebContext();
            return context.Notifications.Where(x => x.Status == false).ToList();
        }

        public int NotificationCountStatusFalse()
        {
            using var context = new WebContext();
            return context.Notifications.Count(x => x.Status == false);
        }
    }
}
