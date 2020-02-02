using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarWorkshop.DataAccess;
using CarWorkshop.WebApi.Features.Users.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.WebApi.Features.Users.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserQuery, bool>
    {
        private readonly CarWorkshopContext _context;

        public DeleteUserHandler(CarWorkshopContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteUserQuery request, CancellationToken cancellationToken)
        {
             
            var user = await _context.Users.FirstAsync(_ => _.Id == request.Id, cancellationToken: cancellationToken);

            _context.Users.Remove(user);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
