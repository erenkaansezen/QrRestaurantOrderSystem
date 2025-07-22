using AutoMapper;
using Web.DtoLayer.TestimonialDto;
using Web.EntityLayer.Entities;

namespace WebAPI.Mapping
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetTestimonailDto>().ReverseMap();
        }
    }
}
