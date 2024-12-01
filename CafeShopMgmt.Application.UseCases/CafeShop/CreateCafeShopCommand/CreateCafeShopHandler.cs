using AutoMapper;
using CafeShopMgmt.Application.Interface.Persistence;
using CafeShopMgmt.Application.UseCases.Commons.Bases;
using CafeShopMgmt.Domain.Entities;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.CafeShop.CreateCafeShopCommand
{
    public class CreateCafeShopHandler : IRequestHandler<CreateCafeShopCommand, BaseResponse<bool>>
    {
        private readonly ICafeShopRepository _cafeShopRepository;
        private readonly IMapper _mapper;

        public CreateCafeShopHandler(ICafeShopRepository cafeShopRepository, IMapper mapper)
        {
            _cafeShopRepository = cafeShopRepository ?? throw new ArgumentNullException(nameof(cafeShopRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<bool>> Handle(CreateCafeShopCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var cafeShop = _mapper.Map<Domain.Entities.CafeShop>(command);

                cafeShop.Status = true;
                
                response.Data = await _cafeShopRepository.AddAsync(cafeShop);
                if (response.Data)
                {
                    response.success = true;
                    response.Message = "Cafe Shop successfully create.";
                }
                else
                {
                    response.success = false;
                    response.Message = "Failed to create cafe Shop.";
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
