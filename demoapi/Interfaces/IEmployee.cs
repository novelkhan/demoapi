using demoapi.Models;

namespace demoapi.Interfaces
{
    public interface IEmployee
    {
        //Get all employees list
        List<EmployeeModel> GetEmployees();

        //Add an employee
        EmployeeModel AddEmployee(EmployeeModel employee);

        //Get an employee
        EmployeeModel GetEmployee(Guid Id);

        //Edit employee
        EmployeeModel EditEmployee(EmployeeModel employee);

        //Delete an employee
        void DeleteEmployee(EmployeeModel employee);
        //void DeleteEmployee(Guid Id);
    }
}
