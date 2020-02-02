using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CarWorkshop.WebApi.Features.Companies.Queries
{
    public class DeleteCompanyQuery : IRequest<bool>
    {
        public DeleteCompanyQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
