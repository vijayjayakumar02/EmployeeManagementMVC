using BusinessLayer.Methods;
using DataAccessLayer.Models;
using DataAccessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : BaseController<EmployeeViewModel>
    {
        private readonly EmployeeBL employeeBL;

        public EmployeeController(EmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }
        public IActionResult Index(int page= 1)
        {
            var listOfEmployees = employeeBL.GetEmployeeList();

            var paginatedResult = PaginatedResult(listOfEmployees, page, 6);

            return View(paginatedResult);
        }

        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeViewModel model)
        {
            employeeBL.CreateEmployee(model);
            return RedirectToAction("Index", "Employee");
        }
    }
}
