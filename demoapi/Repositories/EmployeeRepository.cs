using demoapi.Interfaces;
using demoapi.Models;

namespace demoapi.Repositories
{
    public class EmployeeRepository : IEmployee
    {
        List<EmployeeModel> employees = new List<EmployeeModel>()
        {
            new EmployeeModel
            {
                EmployeeId = Guid.NewGuid(),
                Name= "Employee-1",
            },

            new EmployeeModel
            {
                EmployeeId = Guid.NewGuid(),
                Name= "Employee-2",
            }
        };




        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
            employee.EmployeeId = Guid.NewGuid();
            employees.Add(employee);

            return employee;
        }

        public void DeleteEmployee(EmployeeModel employee)
        {
            employees.Remove(employee);
        }

        public EmployeeModel EditEmployee(EmployeeModel employee)
        {
            var Existed_emp = GetEmployee(employee.EmployeeId);
            Existed_emp.Name = employee.Name;

            return Existed_emp;
        }

        public EmployeeModel GetEmployee(Guid Id)
        {
            EmployeeModel employee = employees.SingleOrDefault(x => x.EmployeeId == Id);

            return employee;
        }

        public List<EmployeeModel> GetEmployees()
        {
            return employees;
        }
    }
}
