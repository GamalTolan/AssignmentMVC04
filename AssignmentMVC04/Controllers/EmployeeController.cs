using Company.Data.Models;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment03MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeesService _employeesService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeesService employeesService ,IDepartmentService departmentService)
        {
            _employeesService = employeesService;
            _departmentService = departmentService;
        }

        public IActionResult Index(string searchInp)
        {
            ViewBag.Message = "Hello From Employee Index(ViewBag)";
            ViewData["TextMessage"] = "Hello From Employee Index(ViewData)";
            TempData["TextTempMessage"]= "Hello From Employee Index(TempData)";
            IEnumerable<EmployeeDto> employees = new List<EmployeeDto>();
            if (string.IsNullOrEmpty(searchInp))
            {
                employees = _employeesService.GetAll();
                return View(employees);
            }
            else
            {
                employees = _employeesService.GetEmployeeByName(searchInp);
                return View(employees);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _departmentService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeesService.Add(employee);
                    TempData["TextTempMessage"] = "Hello From Employee Index(TempData)";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("EmployeeError", "ValidationErrors");
                return View(employee);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("EmployeeError", ex.Message);
                return View(employee);
            }
        }
    }
}
