using CarWorkshop.Core;

namespace CarWorkshop.WebApi.Features.Companies.Dtos
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CarTrademarks CarTrademarks { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
