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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(WebContext context) : base(context)
        {
        }

        public void BookingStatusApproved(int id)
        {
            using var context = new WebContext();
            var values = context.Bookings.Find(id);
            values.Description = "Rezervasyon Onaylandı";
            context.SaveChanges();
            
        }

        public void BookingStatusCancelled(int id)
        {
            using var context = new WebContext();
            var values = context.Bookings.Find(id);
            values.Description = "Rezervasyon İptal Edildi";
            context.SaveChanges();
        }
    }

}
