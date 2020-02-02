using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWorkshop.WebApi.Features.Appointments.Dtos;
using MediatR;

namespace CarWorkshop.WebApi.Features.Appointments.Queries
{
    public class GetAppointmentsQuery : IRequest<IEnumerable<AppointmentDto>>
    {
    }
}
