using HandsOn_.NET8APIWithUnitTesting.Models;
using HandsOn_.NET8APIWithUnitTesting.Repository;
using Moq;

namespace HandsOn_MoqTests
{
    public class MoqTests
    {
        private readonly Mock<IPatientRepository> _mockRepository;

        public MoqTests()
        {
            _mockRepository = new Mock<IPatientRepository>();
        }

        //write moq test for GetAllPatients method  
        [Test]
        public void GetAllPatientsTest()
        {
            //Arrange
            _mockRepository.Setup(p => p.GetAllPatients()).Returns(new List<PatientModel>()
            {
                new PatientModel() { PatientId = 1001, PatientName = "Sam", Age = 39, Email = "sam@gmail.com", MobileNumber = 9600197755, DiseaseName = "Fever" },
                new PatientModel() { PatientId = 1002, PatientName = "Peter", Age = 40, Email = "peter@yahoo.in", MobileNumber = 7606197758, DiseaseName = "Leg Pain" }
            });
            var result = _mockRepository.Object;

            //Act
            var patients = result.GetAllPatients();

            //Assert
            Assert.That(2, Is.EqualTo(patients.Count()));
            }


        //write moq test for GetPatientById method
        [Test]
        public void GetPatientByIdTest()
        {
            //Arrange
            _mockRepository.Setup(p => p.GetPatientById(1001)).Returns(new PatientModel() { PatientId = 1001, PatientName = "Sam", Age = 39, Email = "sam@gmail.com", MobileNumber = 9600197755, DiseaseName = "Fever" }
            );
            var result = _mockRepository.Object;

            //Act
            var patient = result.GetPatientById(1001);

            //Assert
            Assert.That("Sam", Is.EqualTo(patient.PatientName));
        }

         //write moq test for AddPatient method
            [Test]
            public void AddPatientTest()
            {
                //Arrange
                _mockRepository.Setup(p => p.AddPatient(It.IsAny<PatientModel>())).Returns(new PatientModel() { PatientId = 1003, PatientName = "John", Age = 45, Email = "john@hyland.com", MobileNumber = 9600198888, DiseaseName = "Ear Problem" }
                );

                var result = _mockRepository.Object;

                //Act
                var patient = result.AddPatient(new PatientModel() { PatientId = 1003, PatientName = "John", Age = 45, Email = "john@hyland.com", MobileNumber = 9600198888, DiseaseName = "Ear Problem" });

                //Assert
                Assert.That("John", Is.EqualTo(patient.PatientName));
             }

        //write moq test for UpdatePatient method
        [Test]
        public void UpdatePatientTest()
        {
            //Arrange
            _mockRepository.Setup(p => p.UpdatePatient(It.IsAny<PatientModel>(), 1001)).Returns(new PatientModel() { PatientId = 1001, PatientName = "Sam", Age = 39, Email = "sam@gmail.com", MobileNumber = 9600197755, DiseaseName = "Fever" });
            var result = _mockRepository.Object;

            //Act
            var patient = result.UpdatePatient(new PatientModel() { PatientId = 1001, PatientName = "Sam", Age = 39, Email = "samuel@hyland.com", MobileNumber = 6600197755, DiseaseName = "Fever" }, 1001);

            //Assert
            Assert.IsNotNull(patient);

        }

            //write moq test for DeletePatient method
            [Test]
            public void DeletePatientTest()
            {
                //Arrange
                _mockRepository.Setup(p => p.DeletePatient(1001)).Returns(true);
                var result = _mockRepository.Object;

                //Act
                var patient = result.DeletePatient(1001);

                //Assert
                Assert.IsTrue(patient);
            }


        }
}