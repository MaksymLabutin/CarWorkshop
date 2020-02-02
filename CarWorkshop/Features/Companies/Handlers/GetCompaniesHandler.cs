using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarWorkshop.DataAccess;
using CarWorkshop.WebApi.Features.Companies.Dtos;
using CarWorkshop.WebApi.Features.Companies.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.WebApi.Features.Companies.Handlers
{
    public class GetCompaniesHandler : IRequestHandler<GetCompaniesQuery, IEnumerable<CompanyDto>>
    {
        private readonly CarWorkshopContext _context;

        public GetCompaniesHandler(CarWorkshopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompanyDto>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Companies
                .AsNoTracking()
                .Select(_ => new CompanyDto()
                {
                    Id = _.Id,
                    Name = _.Name,
                    City = _.City.Name,
                    Country = _.City.Country.Name,
                    PostalCode = _.City.PostCode,
                    CarTrademarks = _.CarTrademarks

                }).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
