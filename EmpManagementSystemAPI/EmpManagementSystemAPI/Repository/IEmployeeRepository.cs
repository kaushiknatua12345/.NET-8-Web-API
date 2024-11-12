using EmpManagementSystemAPI.Models;

namespace EmpManagementSystemAPI.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeDB>? GetEmployees();
        EmployeeDB? GetEmployeeById(int searchedId);
        EmployeeDB AddEmployee(EmployeeDB employee);
        EmployeeDB? UpdateEmployee(EmployeeDB employee,int searchedId);
        bool DeleteEmployee(int id);
    }
}
