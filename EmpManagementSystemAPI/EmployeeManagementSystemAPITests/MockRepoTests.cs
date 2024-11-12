using Moq;
using EmpManagementSystemAPI.Repository;
using EmpManagementSystemAPI.Models;
using EmpManagementSystemAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagementSystemAPITests
{
    public class MockRepoTests
    {
        private readonly Mock<IEmployeeRepository> _mockRepo;

        public MockRepoTests()
        {
            _mockRepo = new Mock<IEmployeeRepository>();
        }

        //private List<EmployeeDB> GetEmployees()
        //{
        //    List<EmployeeDB> employees = new List<EmployeeDB>
        //    {
        //        new EmployeeDB
        //        {
        //            Id = 1,
        //            Name = "John",
        //            Department = "IT",
        //            Email = "john@hyland.com",
        //            AssignedToWorkStreams = true
        //        },
        //        new EmployeeDB
        //        {
        //            Id = 2,
        //            Name = "Peter",
        //            Department = "Intfrastructure",
        //            Email = "peter@hyland.com",
        //            AssignedToWorkStreams = false
        //        },
        //        new EmployeeDB
        //        {
        //            Id = 3,
        //            Name = "Merry",
        //            Department = "SaaS",
        //            Email = "merry@hyland.com",
        //            AssignedToWorkStreams = true
        //        }
        //    };
        //    return employees;
        //}


        //Fail Test
        [Test]
        public void GetAllEmployees_ReturnsStatusCodeNotFoundIfListIsEmpty()
        {

            //Arrange
            _mockRepo.Setup(x => x.GetEmployees()).Returns((List<EmployeeDB>)null);

            var mockController = new EmployeeAPIController(_mockRepo.Object);

            //Act
            var result = mockController.GetAllEmployees();
            var notFoundResult = result as NotFoundObjectResult;


            //Assert
            Assert.IsNotNull(result);

            Assert.That(notFoundResult.StatusCode, Is.EqualTo((int)HttpStatusCode.NotFound));
        }


        [Test]
        public void GetEmployeeById_ReturnsNotFoundIfSearchedIdNotFound()
        {
            //Arrange
            _mockRepo.Setup(x => x.GetEmployeeById(1001)).Returns(new EmployeeDB
            {
                Id = 1001,
                Name = "Glenda",
                Department = "RDES",
                Email = "Glenda@hyland.com",
                AssignedToWorkStreams = false
            });

            var mockController = new EmployeeAPIController(_mockRepo.Object);
            var result = mockController.GetEmployeeById(1);

            var notFoundResult = result as NotFoundObjectResult;
            Assert.IsNotNull(result);

            Assert.That(notFoundResult.StatusCode, Is.EqualTo((int)HttpStatusCode.NotFound));
        }


        //Pass test

        [Test]
        public void GetAllEmployees_ReturnsAllEmployees()
        {
            //Arrange
            _mockRepo.Setup(x => x.GetEmployees()).Returns(new List<EmployeeDB>
            {
                new EmployeeDB
                {
                    Id = 1001,
                    Name = "Glenda",
                    Department = "RDES",
                    Email = "glenda@hyland.com",
                    AssignedToWorkStreams = false
                },
                new EmployeeDB
                {
                    Id = 1005,
                    Name = "Michal",
                    Department = "IDP",
                    Email = "michal@hyland.com",
                    AssignedToWorkStreams = true
                }
                });

            var mockController = new EmployeeAPIController(_mockRepo.Object);

            //Act
            var result = mockController.GetAllEmployees();

            var okResult = result as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);

            Assert.That(okResult.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
        }

        //Passed Test for GetEmpl;oyeeById
        [Test]
        public void GetEmployeeById_ReturnsEmployeeById()
        {
            //Arrange
            _mockRepo.Setup(x => x.GetEmployeeById(1001)).Returns(new EmployeeDB
            {
                Id = 1001,
                Name = "Glenda",
                Department = "RDES",
                Email = "Glenda@hyland.com",
                AssignedToWorkStreams = false
            });

            var mockController = new EmployeeAPIController(_mockRepo.Object);
            var result = mockController.GetEmployeeById(1001);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(result);

            Assert.That(okResult.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));


        }

    }
        
        

}