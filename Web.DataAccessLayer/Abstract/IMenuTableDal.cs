using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.DataAccessLayer.Abstract
{
    public interface IMenuTableDal : IGenericDal<MenuTable>
    {
        int MenuTableCount();
        int ActiveMenuTableCount();
        int NumberOfEmptyTables();

        void ChangeTableStatusTrue(int id);
        void ChangeTableStatusFalse(int id);


    }
}
