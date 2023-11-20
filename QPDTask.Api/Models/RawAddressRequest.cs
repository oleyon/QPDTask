using AutoMapper;
using QPDTask.Service.Models;

namespace QPDTask.Api.Models
{
    public class RawAddressRequest
    {
        public string RawAddress { get; set; }
    }

    public class AddressMappingProfile : Profile
    {
        public AddressMappingProfile()
        {
            CreateMap<RawAddressRequest, RawAddressModel>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.RawAddress));
        }
    }
}
