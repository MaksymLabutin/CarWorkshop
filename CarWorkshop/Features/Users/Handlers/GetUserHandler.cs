using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarWorkshop.DataAccess;
using CarWorkshop.WebApi.Features.Users.Dtos;
using CarWorkshop.WebApi.Features.Users.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.WebApi.Features.Users.Handlers
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly CarWorkshopContext _context;

        public GetUserHandler(CarWorkshopContext context)
        {
            _context = context;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users
                .AsNoTracking()
                .Select(_ => new UserDto
                {
                    Email = _.Email,
                    Id = _.Id,
                    Name = _.Name,
                    City = _.City.Name,
                    Country = _.City.Country.Name,
                    PostalCode = _.City.PostCode
                })
                .FirstAsync(_ => _.Id == request.Id, cancellationToken: cancellationToken);
        }
    }
}
