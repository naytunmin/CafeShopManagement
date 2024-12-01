namespace CafeShopMgmt.Application.dto
{
    public class CafeShopDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Location { get; set; }
        public int EmployeeCount { get; set; }
     
        public bool Status { get; set; }
    }
}