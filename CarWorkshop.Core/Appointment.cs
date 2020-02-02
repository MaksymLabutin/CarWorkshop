using System;

namespace CarWorkshop.Core
{
    public class Appointment
    {
        public Appointment(int userId, int companyId)
        {
            UserId = userId;
            CompanyId = companyId;
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}