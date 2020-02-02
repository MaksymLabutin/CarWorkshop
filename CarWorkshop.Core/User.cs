
using System.Collections.Generic;

namespace CarWorkshop.Core
{
    public class User
    { 
        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
        
        public int Id { get; set; }
 
        public string Name { get; set; }
      
        public string Email { get; set; } 

        public int CityId { get; set; }
        public City City { get; set; }

    }
}
