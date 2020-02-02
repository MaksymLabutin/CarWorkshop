using System.Collections.Generic;
using CarWorkshop.Core;
using CarWorkshop.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace CarWorkshop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedsController : ControllerBase
    {
        private readonly CarWorkshopContext _context;

        public SeedsController(CarWorkshopContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public void Get()
        {
            if (_context.Countries.Any()) return;

            _context.Countries.AddRange(
                new Country()
                {
                    Name = "Germany",
                    Cities = new List<City>()
                    {
                        new City()
                        {
                            PostCode = "0001",
                            Name = "München"
                        },
                        new City()
                        {
                            PostCode = "0002",
                            Name = "Düsseldorf"
                        },
                        new City()
                        {
                            PostCode = "0003",
                            Name = "Berlin"
                        }
                    }
                },
                new Country()
                {
                    Name = "Switzerland",
                    Cities = new List<City>()
                    {
                        new City()
                        {
                            PostCode = "1001",
                            Name = "Zürich"
                        },
                        new City()
                        {
                            PostCode = "1002",
                            Name = "Geneva"
                        },
                        new City()
                        {
                            PostCode = "1003",
                            Name = "Bern"
                        }
                    }
                });

            _context.SaveChanges();
        }

    }
}
