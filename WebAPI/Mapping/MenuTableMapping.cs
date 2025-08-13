using AutoMapper;
using Web.DtoLayer.MenuTableDto;
using Web.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class MenuTableMapping : Profile
    {
        public MenuTableMapping()
        {
            CreateMap<MenuTable, ResultMenuTableDto>().ReverseMap();
            CreateMap<MenuTable, CreateMenuTableDto>().ReverseMap();
            CreateMap<MenuTable, UpdateMenuTableDto>().ReverseMap();
            CreateMap<MenuTable, GetMenuTableDto>().ReverseMap();
        }
    }
    
    
}
