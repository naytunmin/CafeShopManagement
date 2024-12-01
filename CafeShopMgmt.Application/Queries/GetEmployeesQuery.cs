using MediatR;
using CafeShopMgmt.Application.Dto;
using System.Collections.Generic;

namespace CafeShopMgmt.Application.Queries
{
    public class GetEmployeesQuery : IRequest<EmployeeListResponseDto>
    {
        public string? CafeShopName { get; set; }

        public GetEmployeesQuery(string? cafeShopName)
        {
            CafeShopName = cafeShopName;
        }
    }
}
