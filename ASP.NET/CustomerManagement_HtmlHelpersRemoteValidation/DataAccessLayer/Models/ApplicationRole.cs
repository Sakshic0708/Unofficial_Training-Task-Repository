using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;


namespace DataAccessLayer.Models
{
    [CollectionName("Roles")]
    public class ApplicationRole : MongoIdentityRole<Guid>
    {
        public string? Description { get; set; }
    }
}
