using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarWorkshop.Core;
using CarWorkshop.Core.Extentions;
using CarWorkshop.DataAccess;
using CarWorkshop.WebApi.Features.Companies.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.WebApi.Features.Companies.Handlers
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyQuery, bool>
    {
        private readonly CarWorkshopContext _context;

        public CreateCompanyHandler(CarWorkshopContext context)
        {
            _context = context;
        } 

        public async Task<bool> Handle(CreateCompanyQuery request, CancellationToken cancellationToken)
        { 
            if(string.IsNullOrEmpty(request.Name)) throw new Exception("Name could not be empty");
            var city = await _context.Cities.FirstAsync(_ => _.Id == request.CityId, cancellationToken: cancellationToken);

            if (_context.Users.Any(_ => _.Name == request.Name)) throw new Exception("Name is used");

            ((int)request.CarTrademarks).TryParseEnum<CarTrademarks>(out var carTrademarks);
              
            var nCompany = new Company(request.Name, carTrademarks)
            {
                City = city
            };

            await _context.Companies.AddAsync(nCompany, cancellationToken); 
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
