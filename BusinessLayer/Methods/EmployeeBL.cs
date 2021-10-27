using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Methods
{
    public class EmployeeBL
    {
        private readonly IDapper dapper;

        public EmployeeBL(IDapper dapper)
        {
            this.dapper = dapper;
        }

        public List<EmployeeViewModel> GetEmployeeList()
        {
            var listOfEmployees = dapper.GetEmployees();
            return listOfEmployees;
        }

        public void CreateEmployee(EmployeeViewModel model)
        {
            if(model.FirstName != null)
            {
                Employee employee = new Employee
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    GenderId = model.genderId,
                    DateOfJoining = model.DateOfJoining,
                    Pan = model.Pan,
                    Aadhar = model.Aadhar
                };
                dapper.CreateEmployee(employee);
            }
        }
    }
}
