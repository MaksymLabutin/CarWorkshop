using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarWorkshop.DataAccess;
using CarWorkshop.WebApi.Features.Appointments.Dtos;
using CarWorkshop.WebApi.Features.Appointments.Queries;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.WebApi.Features.Appointments.Handlers
{
    public class ChangeAppointmentDateHandler : IRequestHandler<ChangeAppointmentDateQuery, bool>
    {
        private readonly CarWorkshopContext _context;

        public ChangeAppointmentDateHandler(CarWorkshopContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(ChangeAppointmentDateQuery request, CancellationToken cancellationToken)
        {
            var appointment = await _context.Appointments.FirstAsync(_ => _.Id == request.Id, cancellationToken: cancellationToken);

            appointment.Date = request.Date;
             
            await _context.SaveChangesAsync(cancellationToken);

            _context.SaveChanges();
            return true;
        }
    }
}
