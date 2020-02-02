using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarWorkshop.Core;
using CarWorkshop.Core.Extentions;
using CarWorkshop.DataAccess;
using CarWorkshop.WebApi.Features.Appointments.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.WebApi.Features.Appointments.Handlers
{
    public class CreateAppointmentHandler : IRequestHandler<CreateAppointmentQuery, bool>
    {
        private readonly CarWorkshopContext _context;

        public CreateAppointmentHandler(CarWorkshopContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateAppointmentQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstAsync(_ => _.Id == request.UserId, cancellationToken: cancellationToken);
            var company = await _context.Users.FirstAsync(_ => _.Id == request.CompanyId, cancellationToken: cancellationToken); 

            var nAppointment = new Appointment(user.Id, company.Id)
            {
                Date = request.Date
            };

            await _context.Appointments.AddAsync(nAppointment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
