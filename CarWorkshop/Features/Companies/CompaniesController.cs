using System;
using System.Collections.Generic; 
using System.Threading.Tasks;
using CarWorkshop.Core; 
using CarWorkshop.WebApi.Features.Companies.Dtos;
using CarWorkshop.WebApi.Features.Companies.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc; 

namespace CarWorkshop.WebApi.Features.Companies
{
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        private readonly IMediator _mediator;

        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<CompanyDto>> Get()
        {
            var companies = await _mediator.Send(new GetCompaniesQuery());

            return companies;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var company = await _mediator.Send(new GetCompanyQuery(id));
                return Ok(company);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // GET: api/<controller>
        [HttpGet("~/api/cities/{id}/companies")]
        public async Task<IEnumerable<CompanyDto>> GetInCity(int id)
        {
            return await _mediator.Send(new GetCompaniesInCityQuery(id));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Company dto)
        {
            try
            { 
                await _mediator.Send(new CreateCompanyQuery(dto.Name, dto.CityId, dto.CarTrademarks)); 
                return StatusCode(201);
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
                await _mediator.Send(new DeleteCompanyQuery(id));
                return NoContent();
            }
            catch (Exception e)
            { 
                return NotFound(e.Message);
            }
        }
    }
}
