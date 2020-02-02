using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWorkshop.Core;
using MediatR;

namespace CarWorkshop.WebApi.Features.Companies.Queries
{
    public class CreateCompanyQuery : IRequest<bool>
    {
        public CreateCompanyQuery(string name, int cityId, CarTrademarks carTrademarks)
        {
            Name = name;
            CityId = cityId;
            CarTrademarks = carTrademarks;
        }

        public string Name { get; set; }
        public int CityId { get; set; }
        public CarTrademarks CarTrademarks { get; set; }
    }
}
