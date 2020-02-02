using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CarWorkshop.WebApi.Features.Appointments.Queries
{
    public class DeleteAppointmentQuery : IRequest<bool>
    {
        public DeleteAppointmentQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
