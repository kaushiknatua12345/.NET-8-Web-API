using DotNet8APIWithPostGreSQL.Models;
namespace DotNet8APIWithPostGreSQL.Repositories
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployees();
        public Employee? GetEmployee(int id);
        public Employee? AddEmployee(Employee employee);
        public Employee? UpdateEmployee(Employee employee, int id);
        public bool? DeleteEmployee(int id);
    }
}
