using DataAccessLayer.Models;
using DataAccessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IDapper
    {
        List<EmployeeViewModel> GetEmployees();
        void CreateEmployee(Employee employee);
    }
}
