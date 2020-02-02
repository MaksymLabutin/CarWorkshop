using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWorkshop.Core;
using CarWorkshop.WebApi.Features.Appointments.Dtos;
using CarWorkshop.WebApi.Features.Appointments.Queries;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarWorkshop.WebApi.Features.Appointments
{
    [Route("api/[controller]")]
    public class AppointmentsController : Controller
    {
        private readonly IMediator _mediator;

        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<AppointmentDto>> Get()
        {
            return await _mediator.Send(new GetAppointmentsQuery());
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateAppointmentQuery dto)
        {
            try
            {
                await _mediator.Send(dto);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
         

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ChangeAppointmentDateDto dto)
        { 

            try
            { 
                await _mediator.Send(new ChangeAppointmentDateQuery(id, dto.Date));
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteAppointmentQuery(id));
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);

            }
        }
    }
}
