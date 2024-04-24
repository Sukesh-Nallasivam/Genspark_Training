using ClinicDALLibrary;
using ClinicBLLLibrary;
using ClinicModelLibrary;
namespace DoctorClinicBLLTest
{
    public class TestingAppointmentBLL
    {
        AppointmentRepositoryClass _repository;
        AppointmentRepositoryClass _appointmentRepository;
        IAppointmentService _appointmentService;
        IAppointmentService appointmentService;
        Appointment appointment;
        [SetUp]
        public void TestingAppointmentService_SetUp()
        {
            _repository = new AppointmentRepositoryClass();
            appointment = new Appointment() {Name="albert",PatientContact=123456789};
            _repository.Add(appointment);
            appointment = new Appointment() { Name = "dave", PatientContact = 123453389 };
            _repository.Add(appointment);
            appointmentService = new AppointmentService(_repository);
        }

        [Test]
        public void TestingPatientService_Test()
        {
            //Action
            var appointment1 = appointmentService.GetAppointmentById(2);
            var appointment2 = appointmentService.GetAppointmentById(1);
            //Assert
            Assert.AreEqual("albert", appointment.Name);
            Assert.AreEqual(123456789, appointment.PatientContact);
        }
    }
}