using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataAccessLayer.Models
{
    [Table("Gender")]
    public partial class Gender
    {
        public Gender()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column("Gender")]
        [StringLength(30)]
        public string Gender1 { get; set; }

        [InverseProperty(nameof(Employee.Gender))]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
