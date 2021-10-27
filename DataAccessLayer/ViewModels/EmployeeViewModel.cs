using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        public string Code { get; set; }

        [StringLength(60,MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        //[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateOfJoining { get; set; }

        [Required]
        [StringLength(12,ErrorMessage ="The length of the number should be 12")]
        public string Aadhar { get; set; }
        
        [Required]
        [RegularExpression(@"^[A-Z]{5}\d{4}[A-Z]{1}")]
        public string Pan { get; set; }

        public int genderId { get; set; }

        public string gender { get; set; }
    }
}
