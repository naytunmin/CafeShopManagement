using CafeShopMgmt.Application.UseCases.Commons.Bases;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.CafeShop.DeleteCafeShopCommand
{
    public class DeleteCafeShopCommand : IRequest<BaseResponse<bool>>
    {
        public Guid cafeShopId { get; set; }
    }
}
