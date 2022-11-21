using demoapi.Interfaces;
using demoapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Mime;

namespace demoapi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        protected IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            this._employee = employee;
        }


        // 1. Get all employees
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employee.GetEmployees());
        }


        // 2. Get an employee
        [HttpGet]
        [Route("api/[controller]/{Id}")]
        public IActionResult GetEmployee(Guid Id)
        {
            var employee = _employee.GetEmployee(Id);
            if(employee != null)
            {
                return Ok(employee);
            }

            return NotFound($"The employee with this Id:{Id} is not found");
        }



        //// 3. Edit an employee
        //[HttpPatch]
        //[Route("api/[controller]/{Id}")]
        //public IActionResult EditEmployee(Guid Id, EmployeeModel employee)  //For EmployeeRepository
        //{
        //    var existed_employee = _employee.GetEmployee(Id);
        //    if (existed_employee != null)
        //    {
        //        existed_employee.Name= employee.Name;
        //        return Ok(existed_employee);
        //    }

        //    return NotFound($"The employee with this Id:{Id} is not found");
        //}







        // 3. Edit an employee
        [HttpPatch]
        [Route("api/[controller]/{Id}")]
        public IActionResult EditEmployee(Guid Id, EmployeeModel employee)  //For EmployeeMainRepository
        {
            var existed_employee = _employee.GetEmployee(Id);
            if (existed_employee != null)
            {
                existed_employee.Name = employee.Name;
                var updated_employee = _employee.EditEmployee(existed_employee);
                return Ok(updated_employee);
            }

            return NotFound($"The employee with this Id:{Id} is not found");
        }







        // 4. Delete an employee
        [HttpDelete]
        [Route("api/[controller]/{Id}")]
        public IActionResult DeleteEmployee(Guid Id)
        {
            var existed_employee = _employee.GetEmployee(Id);
            if (existed_employee != null)
            {
                _employee.DeleteEmployee(existed_employee);
                return Ok();
            }

            return NotFound($"The employee with this Id:{Id} is not found");
        }



        // 5. Add an employee
        [HttpPost]
        [Route("api/[controller]")]
        //public IActionResult AddEmployee([FromForm] EmployeeModel employee)
        public IActionResult AddEmployee(EmployeeModel employee)
        {
            _employee.AddEmployee(employee);

            //return Created("~/api/Employee/"+ employee.EmployeeId, employee);
            return CreatedAtAction("GetEmployee", new { Id = employee.EmployeeId }, employee);
        }
    }
}
