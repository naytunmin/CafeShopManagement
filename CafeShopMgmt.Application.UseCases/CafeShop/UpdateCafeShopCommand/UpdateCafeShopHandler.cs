using AutoMapper;
using CafeShopMgmt.Application.Interface.Persistence;
using CafeShopMgmt.Application.UseCases.Commons.Bases;
using CafeShopMgmt.Domain.Entities;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.CafeShop.UpdateCafeShopCommand
{
    public class UpdateCafeShopHandler : IRequestHandler<UpdateCafeShopCommand, BaseResponse<bool>>
    {
        private readonly ICafeShopRepository _cafeShopRepository;
        private readonly IMapper _mapper;

        public UpdateCafeShopHandler(ICafeShopRepository cafeShopRepository, IMapper mapper)
        {
            _cafeShopRepository = cafeShopRepository ?? throw new ArgumentNullException(nameof(cafeShopRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<bool>> Handle(UpdateCafeShopCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var cafeShop = _mapper.Map<Domain.Entities.CafeShop>(command);

                response.Data = await _cafeShopRepository.UpdateAsync(cafeShop);

                if (response.Data)
                {
                    response.success = true;
                    response.Message = "Cafe Shop successfully Update.";
                }
                else
                {
                    response.success = false;
                    response.Message = "Failed to Update cafe Shop.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
