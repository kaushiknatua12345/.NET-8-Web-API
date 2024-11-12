using EmpManagementSystemAPI.Models;

namespace EmpManagementSystemAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<EmployeeDB> _employees;

        public EmployeeRepository() { 
        _employees=new List<EmployeeDB>
        {
            new EmployeeDB
                {
                    Id = 1,
                    Name = "John",
                    Department = "IT",
                    Email = "john@hyland.com",
                    AssignedToWorkStreams = true
                },
                new EmployeeDB
                {
                    Id = 2,
                    Name = "Peter",
                    Department = "Intfrastructure",
                    Email = "peter@hyland.com",
                    AssignedToWorkStreams = false
                },
                new EmployeeDB
                {
                    Id = 3,
                    Name = "Merry",
                    Department = "SaaS",
                    Email = "merry@hyland.com",
                    AssignedToWorkStreams = true
                }
        };

        }
        public EmployeeDB AddEmployee(EmployeeDB employee)
        {
            var addNewEmployee = new EmployeeDB
            {
                Id = employee.Id,
                Name = employee.Name,
                Department = employee.Department,
                Email = employee.Email,
                AssignedToWorkStreams = employee.AssignedToWorkStreams
            };

            _employees.Add(addNewEmployee);
            return addNewEmployee;
        }

        public bool DeleteEmployee(int id)
        {
            var searchedEmployeeIndex=_employees.FindIndex(e => e.Id == id);

            if (searchedEmployeeIndex == -1)
            {
                return false;
            }
            else
                {
                _employees.RemoveAt(searchedEmployeeIndex);
                return true;
            }
        }

        public EmployeeDB? GetEmployeeById(int searchedId)
        {
            return _employees.FirstOrDefault(e => e.Id == searchedId);
        }

        public IEnumerable<EmployeeDB>? GetEmployees()
        {
            if(_employees.Count > 0)
            {
                return _employees;
            }
            else
                {
                return null;
            }
        }

        public EmployeeDB? UpdateEmployee(EmployeeDB employee, int searchedId)
        {
            var searchEmployeeIndex = _employees.FindIndex(e => e.Id == searchedId);

            if (searchEmployeeIndex == -1)
            {
                return null;
            }
            else
            {
                var empoyeeToUpdate=_employees[searchEmployeeIndex];
                empoyeeToUpdate.Name = employee.Name;
                empoyeeToUpdate.Department = employee.Department;
                empoyeeToUpdate.Email = employee.Email;
                empoyeeToUpdate.AssignedToWorkStreams = employee.AssignedToWorkStreams;

                return empoyeeToUpdate;
            }
        }
    }
}
