using DoctorClinicAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;

namespace DoctorClinicAPI.Interfaces
{
    public interface IDoctorService
    {
        //     List Doctors
        //Update Doctor Experience
        //List doctor based on speciality
        public Task<Doctor> AddNewDoctor(Doctor doctor);
        public Task<IEnumerable<Doctor>> GetAllDoctors();
        public Task<Doctor> UpdateDoctorExperience(int DoctorId,int Experience);
        public Task<IEnumerable<Doctor>> GetDoctorsBySpeciality(string Speciality);
        public Task<Doctor> DeleteDoctor(int DoctorId);
    }
}
