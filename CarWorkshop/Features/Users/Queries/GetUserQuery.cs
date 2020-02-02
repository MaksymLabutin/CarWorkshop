﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWorkshop.WebApi.Features.Users.Dtos;
using MediatR;

namespace CarWorkshop.WebApi.Features.Users.Queries
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public GetUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
