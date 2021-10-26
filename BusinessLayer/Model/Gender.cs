using System.Collections.Generic;

namespace BusinessLayer.Model
{
    public partial class Gender
    {
        public Gender()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id
        {
            get; set;
        }
        public string Gender1
        {
            get; set;
        }

        public virtual ICollection<Employee> Employees
        {
            get; set;
        }
    }
}
