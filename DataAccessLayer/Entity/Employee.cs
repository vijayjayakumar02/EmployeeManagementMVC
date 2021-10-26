using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entity
{
    public partial class Employee
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Aadhar { get; set; }
        public string Pan { get; set; }
        public int GenderId { get; set; }

        public virtual Gender Gender { get; set; }
    }
}
