using Microsoft.AspNetCore.Mvc;
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
        [Display(Name = "Customer Name")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Name length much be between 1 and 10 characters in length.")]
        public string? Name { get; set; }

        //[RegularExpression(@"^([\w\.\-] +)@([\w\-] +)((\.(\w){2, 3})+)$")]
        [Remote("CheckExistingEmail", "Customer", ErrorMessage = "Email already exists!")]
        [Required]
        [EmailAddress]
        [UIHint("String")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Enter Your Mobile Number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter 10 Digits")]
        public string? Phone { get; set; }

        [Required]
        public string? Address { get; set; }
        [Display(Name = "ProfilePicture")]
        public string? FilePath { get; set; }
        public string? FileName { get; set; }


    }
  
}
