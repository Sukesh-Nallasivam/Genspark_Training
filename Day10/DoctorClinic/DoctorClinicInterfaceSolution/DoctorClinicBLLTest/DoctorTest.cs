using ClinicDALLibrary;
using ClinicBLLLibrary;
using ClinicModelLibrary;
namespace DoctorClinicBLLTest
{
    public class TestingDoctorClinicBLL
    {
        DoctorRepositoryClass _repository;
        PatientRepositoryClass _patientRepository;
        IPatientService _patientService;
        IDoctorService doctorService;
        [SetUp]
        public void TestingDoctorService_SetUp()
        {
            _repository = new DoctorRepositoryClass();
            Doctor doctor1 = new Doctor() { DoctorName="dr.john",Speciality="Cardiology",Contact=123456789};
            Doctor doctor2 = new Doctor() { DoctorName = "dr.gill", Speciality = "Neurology", Contact = 123456784 };
            _repository.Add(doctor1);
            _repository.Add(doctor2);
            doctorService = new DoctorService(_repository);
        }

        [Test]
        public void TestingDoctorService_Test()
        {
            //Action
            var doctor1 = doctorService.GetDoctorById(100);
            var doctor2 = doctorService.GetDoctorByName("dr.gill");
            //Assert
            Assert.AreEqual(100, doctor1.DoctorId);
            Assert.AreEqual(101, doctor2.DoctorId);
        }
    }
}