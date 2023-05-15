using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }
        public string? Address { get; set; }    
        public string? City { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        //[DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        //[DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        public string? ConfirmPassword { get; set; }
        //[DisplayName("Roles")]
        //public string? RoleId { get; set; }


    }
    public class LoginViewModel
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; } 
    }
    public class RoleViewModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
    }
   
}
