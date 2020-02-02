using System.Threading;
using System.Threading.Tasks;
using CarWorkshop.DataAccess;
using CarWorkshop.WebApi.Features.Appointments.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.WebApi.Features.Appointments.Handlers
{
    public class DeleteAppointmentHandler : IRequestHandler<DeleteAppointmentQuery, bool>
    {
        private readonly CarWorkshopContext _context;

        public DeleteAppointmentHandler(CarWorkshopContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteAppointmentQuery request, CancellationToken cancellationToken)
        {  
            var appointment = await _context.Appointments.FirstAsync(_ => _.Id == request.Id, cancellationToken: cancellationToken);

            _context.Appointments.Remove(appointment);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
