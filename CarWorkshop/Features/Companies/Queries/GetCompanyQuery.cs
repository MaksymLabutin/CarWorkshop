using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWorkshop.WebApi.Features.Companies.Dtos;
using MediatR;

namespace CarWorkshop.WebApi.Features.Companies.Queries
{
    public class GetCompanyQuery : IRequest<CompanyDto>
    {
        public GetCompanyQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
