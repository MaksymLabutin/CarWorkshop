using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWorkshop.WebApi.Features.Appointments.Dtos;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace CarWorkshop.WebApi.Features.Appointments.Queries
{
    public class ChangeAppointmentDateQuery : IRequest<bool>
    {
        public ChangeAppointmentDateQuery(int id, DateTime date)
        {
            Id = id;
            Date = date;
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

    }
}
