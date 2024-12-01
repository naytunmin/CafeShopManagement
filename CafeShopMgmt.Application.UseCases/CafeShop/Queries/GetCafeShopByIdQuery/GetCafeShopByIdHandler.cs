using AutoMapper;
using CafeShopMgmt.Application.dto;
using CafeShopMgmt.Application.Interface.Persistence;
using CafeShopMgmt.Application.UseCases.Commons.Bases;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.CafeShop.Queries.GetCafeShopByIdQuery
{
    public class GetCafeShopByIdHandler : IRequestHandler<GetCafeShopByIdQuery, BaseResponse<List<CafeShopDto>>>
    {
        private readonly ICafeShopRepository _cafeShopRepository;
        private readonly IMapper _mapper;

        public GetCafeShopByIdHandler(ICafeShopRepository cafeShopRepository, IMapper mapper)
        {
            _cafeShopRepository = cafeShopRepository ?? throw new ArgumentNullException(nameof(cafeShopRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<List<CafeShopDto>>> Handle(GetCafeShopByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<List<CafeShopDto>>();

            try
            {
                var cafeShop = await _cafeShopRepository.GetCafeShopByIdAsync(request.cafeShopId);

                if(cafeShop is not null)
                {
                    response.Data = _mapper.Map<List<CafeShopDto>>(cafeShop);
                    response.success = true;
                    response.Message = "succeed";
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
