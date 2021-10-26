using Dapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Method
{
    public class CrudDAL : ICrudDAL
    {
        private readonly string _connectionString;

        public CrudDAL(string connectionString)
        {
            this._connectionString = connectionString;
        }

        #region Create employee
        /// <summary>
        /// method for creating new employee
        /// </summary>
        /// <param name="employee"></param>
        /// 
        public void Create(Employee employee)
        {
            
            try
            {
               
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Query("EXECUTE spCreate @Code, @FirstName, @LastName, @Email, @DateOfJoining, @Aadhar, @PAN, @GenderId",
                        new
                        {
                            employee.Code,
                            employee.FirstName,
                            employee.LastName,
                            employee.Email,
                            employee.DateOfJoining,
                            employee.Aadhar,
                            employee.Pan,
                            employee.GenderId
                        });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Delete employee
        /// <summary>
        /// delete the employee with the respective id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Query("EXECUTE spDelete @Id", new
                    {
                        @Id = id
                    });                 
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Get employee
        /// <summary>
        /// get a single employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee Get(int id)
        {
            try
            {
                var employee = new Employee();
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    employee = sqlConnection.Query<Employee>("EXECUTE spGet @Id", new
                    {
                        @Id = id
                    }).FirstOrDefault();
                    return employee;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Get all employee
        /// <summary>
        /// getting all employee
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetAll()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    List<Employee> employeeList = new List<Employee>();
                    employeeList = sqlConnection.Query<Employee>("EXECUTE spGetAll").ToList();
                    return employeeList;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Update employee
        /// <summary>
        /// updating employee with id
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Update(Employee employee)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Query("EXECUTE spUpdate @Id, @Code, @FirstName, @LastName, @Email, @DateOfJoining, @Aadhar, @PAN, @GenderId",
                        new
                        {
                            employee.Id,
                            employee.Code,
                            employee.FirstName,
                            employee.LastName,
                            employee.Email,
                            employee.DateOfJoining,
                            employee.Aadhar,
                            employee.Pan,
                            employee.Gender
                                                
                        }
                        );
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
