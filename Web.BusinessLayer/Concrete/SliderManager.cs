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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void TAdd(Slider entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Slider entity)
        {
            throw new NotImplementedException();
        }

        public List<Slider> TGetAll()
        {
            return _sliderDal.GetAll();
        }

        public Slider TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Slider entity)
        {
            throw new NotImplementedException();
        }
    }
}
