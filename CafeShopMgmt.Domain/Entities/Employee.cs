namespace CafeShopMgmt.Domain.Entities
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public char Gender { get; set; }
        public bool Status { get; set; }
        public Guid? CafeShopId { get; set; }
        public DateTime? StartWorkingDate { get; set; }
    }
}
