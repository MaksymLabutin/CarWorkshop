using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWorkshop.WebApi.Features.Companies.Dtos;
using MediatR;

namespace CarWorkshop.WebApi.Features.Companies.Queries
{
    public class GetCompaniesQuery : IRequest<IEnumerable<CompanyDto>>
    {
    }
}
