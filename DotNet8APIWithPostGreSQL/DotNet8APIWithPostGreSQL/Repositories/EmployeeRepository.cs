using DotNet8APIWithPostGreSQL.Models;

namespace DotNet8APIWithPostGreSQL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public Employee? AddEmployee(Employee employee)
        {
            var result = _context.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
            if (result != null)
            {
                return null;
            }
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public bool? DeleteEmployee(int id)
        {
            var result = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (result == null)
            {
                return false;
            }
            _context.Employees.Remove(result);
            _context.SaveChanges();
            return true;
        }

        public Employee? GetEmployee(int id)
        {
            var result = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);

            if (result == null)
            {
                return null;
            }
            return result;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            if (_context.Employees.Count() == 0)
            {
                return null;
            }
            return _context.Employees;
        }

        public Employee? UpdateEmployee(Employee employee, int id)
        {
            var result = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (result == null)
            {
                return null;
            }
            else
            {
                result.EmployeeName = employee.EmployeeName;
                result.Department = employee.Department;
                result.Email = employee.Email;
                result.MobileNumber = employee.MobileNumber;
                _context.SaveChanges();
                return result;
            }
        }
    }
}
    