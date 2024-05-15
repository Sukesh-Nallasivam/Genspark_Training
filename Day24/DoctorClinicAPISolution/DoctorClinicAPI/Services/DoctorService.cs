using DoctorClinicAPI.Interfaces;
using DoctorClinicAPI.Models;
using DoctorClinicAPI.Repositories;

namespace DoctorClinicAPI.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<int, Doctor> _repository;
        public DoctorService(IRepository<int,Doctor> repository)
        {
            _repository=repository;
        }

        public async Task<Doctor> AddNewDoctor(Doctor doctor)
        {
            return await _repository.Add(doctor);
        }

        public async Task<Doctor> DeleteDoctor(int doctorId)
        {
            return await _repository.Delete(doctorId);
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await _repository.Get();
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsBySpeciality(string speciality)
        {
            var doctors = await _repository.Get();
            return doctors.Where(d => d.Speciality == speciality);
        }

        public async Task<Doctor> UpdateDoctorExperience(int doctorId, int experience)
        {
            var doctor = await _repository.Get(doctorId);
            if (doctor == null)
            {
                throw new NoDoctorExcemption();
            }

            doctor.Experience = experience;
            return await _repository.Update(doctor);
        }
    }
}
