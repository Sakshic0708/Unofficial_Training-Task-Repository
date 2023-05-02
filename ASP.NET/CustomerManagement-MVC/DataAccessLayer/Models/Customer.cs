using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "Name length much be between 1 and 3 characters in length.")]
        public string? Name { get; set; }

        //[RegularExpression(@"^([\w\.\-] +)@([\w\-] +)((\.(\w){2, 3})+)$")]
        [EmailAddress(ErrorMessage ="Please Enter Valid Email Formate")]
        [Required]
        public string? Email { get; set; }

    
        [Required(ErrorMessage = "Enter Your Mobile Number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter 10 Digits")]
        public string? Phone { get; set; }

        [Required]
        public string? Address { get; set; }
    }
}
