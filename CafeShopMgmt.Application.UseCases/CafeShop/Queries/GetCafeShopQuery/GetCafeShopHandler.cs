using AutoMapper;
using CafeShopMgmt.Application.dto;
using CafeShopMgmt.Application.Interface.Persistence;
using CafeShopMgmt.Application.UseCases.Commons.Bases;
using CafeShopMgmt.Application.UseCases.Employee.Queries.GetEmployeeQuery;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.CafeShop.Queries.GetCafeShopQuery
{
    public class GetCafeShopHandler : IRequestHandler<GetCafeShopQuery, BaseResponse<List<CafeShopDto>>>
    {
        private readonly ICafeShopRepository _cafeShopRepository;
        private readonly IMapper _mapper;

        public GetCafeShopHandler(ICafeShopRepository cafeShopRepository, IMapper mapper)
        {
            _cafeShopRepository = cafeShopRepository ?? throw new ArgumentNullException(nameof(cafeShopRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<List<CafeShopDto>>> Handle(GetCafeShopQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<List<CafeShopDto>>();

            try
            {
                var cafeShops = await _cafeShopRepository.GetCafeShopAsync(request.location);

                if(cafeShops is not null)
                {
                    response.Data = _mapper.Map<List<CafeShopDto>>(cafeShops);
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
