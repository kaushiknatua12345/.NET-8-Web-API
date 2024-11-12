using DotNet8APIWithPostGreSQL.Models;
using DotNet8APIWithPostGreSQL.Repositories;
using DotNet8APIWithPostGreSQL.Controllers;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
namespace EmplyeeAPITests
{
    public class TestRepositories
    {
        //write mock test for EmployeeRepository and controller
        private readonly Mock<IEmployeeRepository> mockRepo;
        public TestRepositories() {        
        mockRepo = new Mock<IEmployeeRepository>();
        }

        [Test]
        public void TestGetEmployees_ResponseCodeOk_WhenDataPresent()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee { EmployeeId = 1, EmployeeName = "John", Department = "IT", Email = "John@hyland.com", MobileNumber = 9600197755 },
                new Employee { EmployeeId = 2, EmployeeName = "Smith", Department = "HR", Email = "Smith@hyland.com", MobileNumber = 9600197756 },
                new Employee { EmployeeId = 3, EmployeeName = "Ravi", Department = "IT", Email = "Ravi@hyland.com", MobileNumber = 9600197757 }
            };

            mockRepo.Setup(repo => repo.GetEmployees()).Returns(employees);
            var controller = new EmployeeController(mockRepo.Object);

            // Act
            var result = controller.GetEmployees();

            // Assert
            var actionResult = result as OkObjectResult;            
            Assert.That(actionResult.StatusCode, Is.EqualTo(200));
        }   
        
        [Test]
        public void TestGetEmployees_ResponseCodeNotFound_WhenNoDataPresent()
        {
            // Arrange
            mockRepo.Setup(repo => repo.GetEmployees()).Returns((IEnumerable<Employee>)null);
            var controller = new EmployeeController(mockRepo.Object);

            // Act
            var result = controller.GetEmployees();

            // Assert
            var actionResult = result as NotFoundObjectResult;            
            Assert.That(actionResult.StatusCode, Is.EqualTo(404));
        }

        [Test]
        //Test case for GetEmployee method
        public void TestGetEmployee_ResponseCodeOk_WhenDataPresent()
        {
            // Arrange
            var employee = new Employee { EmployeeId = 1, EmployeeName = "John", Department = "IT", Email = "John@hyland.com", MobileNumber = 9600197755 };
            mockRepo.Setup(repo => repo.GetEmployee(1)).Returns(employee);
            var controller = new EmployeeController(mockRepo.Object);

            // Act
            var result = controller.GetEmployee(1);
            var actionResult = result as OkObjectResult;

            // Assert
            Assert.That(actionResult.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void TestGetEmployee_ResponseCodeNotFound_WhenNoDataPresent()
        {
            // Arrange
            mockRepo.Setup(repo => repo.GetEmployee(1)).Returns((Employee)null);
            var controller = new EmployeeController(mockRepo.Object);

            // Act
            var result = controller.GetEmployee(1);
            var actionResult = result as NotFoundObjectResult;

            // Assert
            Assert.That(actionResult.StatusCode, Is.EqualTo(404));
        }

        [Test]
        public void TestAddEmployee_ResponseCodeOk_WhenDataAdded()
        {
            // Arrange
            var employee = new Employee { EmployeeId = 1, EmployeeName = "John", Department = "IT", Email = "John@hyland.com", MobileNumber = 9600197755 };
            mockRepo.Setup(repo => repo.AddEmployee(employee)).Returns(employee);
            var controller = new EmployeeController(mockRepo.Object);

            // Act
            var result = controller.AddEmployee(employee);
            var actionResult = result as OkObjectResult;

            // Assert
            Assert.That(actionResult.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void TestAddEmployee_ResponseCodeBadRequest_WhenDataAlreadyPresent()
        {
            // Arrange
            var employee = new Employee { EmployeeId = 1, EmployeeName = "John", Department = "IT", Email = "John@hyland.com", MobileNumber = 9600197755 };
            mockRepo.Setup(repo => repo.AddEmployee(employee)).Returns((Employee)null);
            var controller = new EmployeeController(mockRepo.Object);

            // Act
            var result = controller.AddEmployee(employee);
            var actionResult = result as BadRequestObjectResult;

            // Assert
            Assert.That(actionResult.StatusCode, Is.EqualTo(400));
        }

        [Test]
        //Test case for UpdateEmployee method
        public void TestUpdateEmployee_ResponseCodeOk_WhenDataUpdated()
        {
            // Arrange
            var employee = new Employee { EmployeeId = 1, EmployeeName = "John", Department = "IT", Email = "John.Phen@hyland.com", MobileNumber = 8100035013 };
            mockRepo.Setup(repo => repo.UpdateEmployee(employee, 1)).Returns(employee);
            var controller = new EmployeeController(mockRepo.Object);

            // Act
            var result = controller.UpdateEmployee(employee, 1);
            var actionResult = result as OkObjectResult;

            // Assert
            Assert.That(actionResult.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void TestUpdateEmployee_ResponseCodeNotFound_WhenNoDataPresent()
        {
            // Arrange
            var employee = new Employee { EmployeeId = 1, EmployeeName = "John", Department = "IT", Email = "John.Phen@hyland.com", MobileNumber = 8100035013 };

            mockRepo.Setup(repo => repo.UpdateEmployee(employee, 1)).Returns((Employee)null);
            var controller = new EmployeeController(mockRepo.Object);

            // Act
            var result = controller.UpdateEmployee(employee, 1001);
            var actionResult = result as NotFoundObjectResult;

            // Assert
            Assert.That(actionResult.StatusCode, Is.EqualTo(404));
        }

        [Test]
        //Test case for DeleteEmployee method
        public void TestDeleteEmployee_ResponseCodeOk_WhenDataDeleted()
        {
            var employee = new Employee { EmployeeId = 1, EmployeeName = "John", Department = "IT", Email = "John.Phen@hyland.com", MobileNumber = 8100035013 };
            // Arrange
            mockRepo.Setup(repo => repo.DeleteEmployee(1)).Returns(true);
            var controller = new EmployeeController(mockRepo.Object);

            // Act
            var result = controller.DeleteEmployee(1);
            var actionResult = result as OkObjectResult;

            // Assert
            Assert.That(actionResult.StatusCode, Is.EqualTo(200));
        }

       

    }
}