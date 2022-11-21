using demoapi.Data;
using demoapi.Interfaces;
using demoapi.Models;
using Microsoft.EntityFrameworkCore;

namespace demoapi.Repositories
{
    public class EmployeeMainRepository : IEmployee
    {
        private EmployeeDbContext _employeeContext;
        public EmployeeMainRepository(EmployeeDbContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
            employee.EmployeeId = Guid.NewGuid();
            _employeeContext.employees.Add(employee);
            _employeeContext.SaveChanges();

            return employee;
        }

        public void DeleteEmployee(EmployeeModel employee)
        {
            var existed_employee = _employeeContext.employees.Find(employee.EmployeeId);

            if (existed_employee != null)
            {
                _employeeContext.employees.Remove(employee);
                _employeeContext.SaveChanges();
            }
        }

        public EmployeeModel EditEmployee(EmployeeModel employee)
        {
            var existed_employee = _employeeContext.employees.Find(employee.EmployeeId);

            if(existed_employee != null)
            {
                _employeeContext.employees.Update(employee);
                _employeeContext.SaveChanges();
            }

            return employee;
        }

        public EmployeeModel GetEmployee(Guid Id)
        {
            return _employeeContext.employees.Find(Id);
        }

        public List<EmployeeModel> GetEmployees()
        {
            return _employeeContext.employees.ToList();
        }
    }
}
