using ClinicModelLibrary;
using ClinicDALLibrary;

namespace ClinicBLLLibrary
{
    public class PatientService : IPatientService
    {
        private readonly PatientRepositoryClass _patientRepository;

        public PatientService(PatientRepositoryClass patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public void AddPatient(Patient patient)
        {
            try
            {
                _patientRepository.Add(patient);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding patient {ex.Message}");
            }
        }

        public void DeletePatient(int id)
        {
            try
            {
                _patientRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting patient");
            }
        }

        public Patient GetPatientById(int id)
        {
            try
            {
                return _patientRepository.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting patient by ID");
            }
        }


        void IPatientService.UpdatePatient(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
