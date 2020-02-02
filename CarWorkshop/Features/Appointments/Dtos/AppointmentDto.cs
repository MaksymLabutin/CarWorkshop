using System;

namespace CarWorkshop.WebApi.Features.Appointments.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string CompanyName { get; set; }
        public string UserName { get; set; } 
    }
}
