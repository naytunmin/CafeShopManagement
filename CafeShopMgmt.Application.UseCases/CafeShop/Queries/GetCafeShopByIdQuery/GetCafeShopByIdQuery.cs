using CafeShopMgmt.Application.dto;
using CafeShopMgmt.Application.UseCases.Commons.Bases;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.CafeShop.Queries.GetCafeShopByIdQuery
{    
    public class GetCafeShopByIdQuery : IRequest<BaseResponse<List<CafeShopDto>>>
    {
        public Guid cafeShopId { get; set; }
    }
}
