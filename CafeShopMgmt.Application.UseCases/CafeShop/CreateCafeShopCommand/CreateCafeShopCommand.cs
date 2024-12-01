using CafeShopMgmt.Application.UseCases.Commons.Bases;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.CafeShop.CreateCafeShopCommand
{
    public class CreateCafeShopCommand : IRequest<BaseResponse<bool>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Logo { get; set; }
        public string Location { get; set; }
    }
}
