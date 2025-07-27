using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.BusinessLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        int TTotalOrderCount();
        int TActiveOrderCount();
        decimal TLastOrderPrice();
        decimal TTodayTotalPrice();
    }
}
