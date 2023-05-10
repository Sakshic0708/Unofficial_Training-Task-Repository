using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace DataAccessLayer.Models
{
    [CollectionName("ApplicationUsers")]
    public class ApplicationUser: MongoIdentityUser<Guid>
    {
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }    
    }
}
