using AutoMapper;
using CafeShopMgmt.Application.dto;
using CafeShopMgmt.Application.UseCases.CafeShop.CreateCafeShopCommand;
using CafeShopMgmt.Application.UseCases.CafeShop.UpdateCafeShopCommand;
using CafeShopMgmt.Domain.Entities;

namespace CafeShopMgmt.Application.UseCases.Commons.Mappings
{
    public class CafeShopMapper : Profile
    {
        public CafeShopMapper()
        {
            CreateMap<Domain.Entities.CafeShop, CafeShopDto>().ReverseMap();
            CreateMap<Domain.Entities.CafeShop, CreateCafeShopCommand>().ReverseMap();
            CreateMap<Domain.Entities.CafeShop, UpdateCafeShopCommand>().ReverseMap();
        }
    }
}
