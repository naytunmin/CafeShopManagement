using CafeShopMgmt.Domain.Entities;

namespace CafeShopMgmt.Application.dto
{
    public class EmployeeDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int DaysWorked { get; set; }
        public string CafeShopName { get; set; }

        public char Gender { get; set; }
        public bool Status { get; set; }
        public Guid? CafeShopId { get; set; }
    }
}
