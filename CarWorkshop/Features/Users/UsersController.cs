using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarWorkshop.Core;
using CarWorkshop.WebApi.Features.Users.Dtos;
using CarWorkshop.WebApi.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.WebApi.Features.Users
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get()
        {
            IEnumerable<UserDto> users = await _mediator.Send(new GetUsersQuery()).ConfigureAwait(false);
            return users; 
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                UserDto user = await _mediator.Send(new GetUserQuery(id)).ConfigureAwait(false);
                return Ok(user); 
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        //// POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUserQuery dto)
        {
            try
            {
                await _mediator.Send(dto).ConfigureAwait(false);
                
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        //// DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteUserQuery(id)).ConfigureAwait(false);

                return NoContent();
            }
            catch (Exception e)
            { 
                return NotFound(e.Message);  
            }
        }
    }
}
