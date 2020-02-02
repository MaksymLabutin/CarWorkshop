using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CarWorkshop.WebApi.Features.Users.Queries
{
    public class DeleteUserQuery : IRequest<bool>
    {

        public DeleteUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
