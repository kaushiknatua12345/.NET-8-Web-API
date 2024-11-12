using HandsOn_.NET8APIWithUnitTesting.Models;
namespace HandsOn_.NET8APIWithUnitTesting.Repository
{
    public interface IPatientRepository
    {
        //add method to get all patients
        IEnumerable<PatientModel> GetAllPatients();
        //add method to get patient by id
        PatientModel? GetPatientById(int id);
        //add method to add patient
        PatientModel AddPatient(PatientModel patient);
        //add method to update patient
        PatientModel? UpdatePatient(PatientModel patient, int id);
        //add method to delete patient
        bool DeletePatient(int id);
    }
}
