using HandsOn_.NET8APIWithUnitTesting.Models;

namespace HandsOn_.NET8APIWithUnitTesting.Repository
{
    public class PatientRepository:IPatientRepository
    {
        private readonly static List<PatientModel> patients;

        static PatientRepository()
        {
            patients = new List<PatientModel>()
            {
                new PatientModel() { PatientId = 1, PatientName = "Kaushik", Age = 37, Email = "kaushik@gmail.com", MobileNumber = 9600197755, DiseaseName = "Fever" },
                new PatientModel() { PatientId = 2, PatientName = "Rajdip", Age = 40, Email = "raj@gmail.com", MobileNumber = 7606197755, DiseaseName = "Leg Pain" }
            };
        }


        //implement all methods
        public PatientModel AddPatient(PatientModel patient)
        {
            var addPatient = new PatientModel()
            {
                PatientId = patient.PatientId,
                PatientName = patient.PatientName,
                Age = patient.Age,
                Email = patient.Email,
                MobileNumber = patient.MobileNumber,
                DiseaseName = patient.DiseaseName
            };
            patients.Add(addPatient);
            return addPatient;
            
        }        

        public IEnumerable<PatientModel> GetAllPatients()
        {
            return patients;
        }

        public PatientModel? GetPatientById(int id)
        {
            return patients.FirstOrDefault(p => p.PatientId == id);
        }

        public PatientModel? UpdatePatient(PatientModel patient, int id)
        {
            var searchPatientIndex = patients.FindIndex(p => p.PatientId == id); 
            if(searchPatientIndex > 0)
            {
                var patientUpdate = patients[searchPatientIndex];
                patientUpdate.PatientName = patient.PatientName;
                patientUpdate.Age = patient.Age;
                patientUpdate.Email = patient.Email;
                patientUpdate.MobileNumber = patient.MobileNumber;
                patientUpdate.DiseaseName = patient.DiseaseName;
                patients[searchPatientIndex] = patientUpdate;   
                return patientUpdate;
            }
            else
            {

               return null;
            }
        }

        public bool DeletePatient(int id)
        {
            var patientIndex = patients.FindIndex(p => p.PatientId == id);
            if(patientIndex > 0)
            {
                patients.RemoveAt(patientIndex);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
