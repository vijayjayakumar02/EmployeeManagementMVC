using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataAccessLayer.Models
{
    [Table("employee")]
    public partial class Employee
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(4)]
        public string Code { get; set; }
        [Required]
        [StringLength(26)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(26)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateOfJoining { get; set; }
        [Required]  
        [StringLength(16)]
        public string Aadhar { get; set; }
        [Required]
        [Column("PAN")]
        [StringLength(20)]
        public string Pan { get; set; }
        public int GenderId { get; set; }

        [ForeignKey(nameof(GenderId))]
        [InverseProperty("Employees")]
        public virtual Gender Gender { get; set; }
    }
}
