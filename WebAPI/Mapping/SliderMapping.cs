using AutoMapper;
using Web.DtoLayer.FeatureDto;
using Web.DtoLayer.SliderDto;
using Web.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class SliderMapping : Profile
    {
        public SliderMapping()
        {
            CreateMap<Slider, ResultSliderDto>().ReverseMap();
            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            CreateMap<Slider, UpdateSliderDto>().ReverseMap();
            CreateMap<Slider, Web.DtoLayer.FeatureDto.GetSliderDto>().ReverseMap();
        }
    }
}
