using CafeShopMgmt.Application.dto;
using CafeShopMgmt.Application.UseCases.Commons.Bases;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.CafeShop.Queries.GetCafeShopQuery
{
    public class GetCafeShopQuery : IRequest<BaseResponse<List<CafeShopDto>>>
    {
        public string? location { get; set; }
    }
}
