using CafeShopMgmt.Application.UseCases.Commons.Bases;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.CafeShop.UpdateCafeShopCommand
{
    public class UpdateCafeShopCommand: IRequest<BaseResponse<bool>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Logo { get; set; }
        public string Location { get; set; }
        public bool Status { get; set; }
    }
}
