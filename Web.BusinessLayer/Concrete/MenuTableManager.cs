using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.BusinessLayer.Abstract;
using Web.DataAccessLayer.Abstract;
using Web.EntityLayer.Entities;

namespace Web.BusinessLayer.Concrete
{
    public class MenuTableManager : IMenuTableService
    {
        private readonly IMenuTableDal _menuTableDal;
        public MenuTableManager(IMenuTableDal menuTableDal)
        {
            _menuTableDal = menuTableDal;
        }
        public void TAdd(MenuTable entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(MenuTable entity)
        {
            throw new NotImplementedException();
        }

        public List<MenuTable> TGetAll()
        {
            throw new NotImplementedException();
        }

        public MenuTable TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public int TMenuTableCount()
        {
            return _menuTableDal.MenuTableCount();
        }

        public int TNumberOfEmptyTables()
        {
            return _menuTableDal.NumberOfEmptyTables();
        }

        public void TUpdate(MenuTable entity)
        {
            throw new NotImplementedException();
        }
    }
}
