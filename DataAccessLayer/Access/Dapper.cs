using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.ViewModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Access
{
    public class Dapper:IDapper
    {
        private readonly string connectionstring;

        public Dapper(string connectionString)
        {
            this.connectionstring = connectionString;
        }

        public List<EmployeeViewModel> GetEmployees()
        {
            List<EmployeeViewModel> employees = new();
            using(SqlConnection connection = new SqlConnection(connectionstring))
            {
                employees = connection.Query<EmployeeViewModel>("execute uspGetAllEmployee").ToList();
            }
            return employees;
        }

        public void CreateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Query("Execute uspInsertEmployee @Firstname,@Lastname,@Email,@GenderId,@DateOfJoining,@Aadhar,@pan", new {@Firstname = employee.FirstName,@Lastname = employee.LastName,@Email = employee.Email,@GenderId = employee.GenderId,@DateOfJoining = employee.DateOfJoining, @Aadhar=employee.Aadhar, @pan=employee.Pan }); 
            }
        }
    }
}
