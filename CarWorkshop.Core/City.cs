using System.Collections.Generic;

namespace CarWorkshop.Core
{
    public class City
    {
      
        public int Id { get; set; }

        public string Name { get; set; }
        public string PostCode { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }
         

    }
}