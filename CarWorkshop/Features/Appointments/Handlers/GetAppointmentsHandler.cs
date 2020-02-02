using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarWorkshop.DataAccess;
using CarWorkshop.WebApi.Features.Appointments.Dtos;
using CarWorkshop.WebApi.Features.Appointments.Queries;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.WebApi.Features.Appointments.Handlers
{
    public class GetAppointmentsHandler : IRequestHandler<GetAppointmentsQuery, IEnumerable<AppointmentDto>>
    {
        private readonly CarWorkshopContext _context;

        public GetAppointmentsHandler(CarWorkshopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppointmentDto>> Handle(GetAppointmentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Appointments
                .AsNoTracking()
                .Select(_ => new AppointmentDto()
                {
                    Id = _.Id,
                    CompanyName = _.Company.Name,
                    Date = _.Date,
                    UserName = _.User.Name
                }).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
