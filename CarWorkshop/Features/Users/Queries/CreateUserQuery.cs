using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CarWorkshop.WebApi.Features.Users.Queries
{
    public class CreateUserQuery : IRequest<bool>
    {
        public CreateUserQuery(int cityId, string name, string email)
        {
            CityId = cityId;
            Name = name;
            Email = email;
        }

        public int CityId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
