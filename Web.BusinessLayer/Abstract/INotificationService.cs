using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.BusinessLayer.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        int TNotificationCountStatusFalse();
        List<Notification> TGetAllNotificationsByStatusFalse();
        void TNotificationStatusChangeTrue(int id);
        void TNotificationStatusChangeFalse(int id);
    }
}
