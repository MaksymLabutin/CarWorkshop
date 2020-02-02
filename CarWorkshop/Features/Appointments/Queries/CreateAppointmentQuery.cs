using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CarWorkshop.WebApi.Features.Appointments.Queries
{
    public class CreateAppointmentQuery : IRequest<bool>
    {
        public CreateAppointmentQuery(int userId, int companyId, DateTime date)
        {
            UserId = userId;
            CompanyId = companyId;
            Date = date;
        }

        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public DateTime Date { get; set; }
    }
}
