using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarWorkshop.Core;
using CarWorkshop.DataAccess;
using CarWorkshop.WebApi.Features.Users.Dtos;
using CarWorkshop.WebApi.Features.Users.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.WebApi.Features.Users.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserQuery, bool>
    {
        private readonly CarWorkshopContext _context;

        public CreateUserHandler(CarWorkshopContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateUserQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name)) throw new Exception("Name could not be empty");

            var city = await _context.Cities.FirstAsync(_ => _.Id == request.CityId, cancellationToken: cancellationToken);

            if (_context.Users.Any(_ => _.Name == request.Name || _.Email == request.Email)) throw new Exception("Emair or name is used");

            var nUser = new User(request.Name, request.Email)
            {
                City = city
            };

            await _context.Users.AddAsync(nUser, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
