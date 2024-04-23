using ClinicDALLibrary;
using ClinicBLLLibrary;
using ClinicModelLibrary;
namespace DoctorClinicBLLTest
{
    public class TestingPatientClinicBLL
    {
        PatientRepositoryClass _repository;
        PatientRepositoryClass _patientRepository;
        IPatientService _patientService;
        IPatientService patientService;
        Patient patient;
        [SetUp]
        public void TestingDoctorService_SetUp()
        {
            _repository = new PatientRepositoryClass();
            patient = new Patient() {PatientName="Serge",PatientAge=45};
            _repository.Add(patient);
            patient = new Patient() { PatientName = "Bob", PatientAge = 67 };            
            _repository.Add(patient);
            patientService = new PatientService(_repository);
        }

        [Test]
        public void TestingPatientService_Test()
        {
            //Action
            var patient1 = patientService.GetPatientById(100);
            var patient2 = patientService.UpdatePatient;
            //Assert
            Assert.AreEqual(100, patient1.PatientAge);
            Assert.AreEqual(101, patient2.Target);
        }
    }
}