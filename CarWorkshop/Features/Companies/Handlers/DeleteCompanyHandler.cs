using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarWorkshop.DataAccess;
using CarWorkshop.WebApi.Features.Companies.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.WebApi.Features.Companies.Handlers
{
    public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyQuery, bool>
    {
        private readonly CarWorkshopContext _context;

        public DeleteCompanyHandler(CarWorkshopContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FirstAsync(_ => _.Id == request.Id, cancellationToken: cancellationToken);

            _context.Companies.Remove(company);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
