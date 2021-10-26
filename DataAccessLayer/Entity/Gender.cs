using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entity
{
    public partial class Gender
    {
        public Gender()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Gender1 { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
