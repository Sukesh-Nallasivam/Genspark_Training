using DoctorClinicAPI.Context;
using DoctorClinicAPI.Interfaces;
using DoctorClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using DoctorClinicAPI.Exceptions;

namespace DoctorClinicAPI.Repositories
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly DoctorClinicContext _context;
        public DoctorRepository(DoctorClinicContext context) 
        {
            _context = context;
        }
        public async Task<Doctor> Add(Doctor entity)
        {
            _context.Doctors.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Doctor> Delete(int id)
        {
            var doctor = await Get(id);
            if(doctor!=null)
            {
                _context.Remove(doctor);
                _context.SaveChanges(true);
                return doctor;
            }
            throw new NoDoctorExcemption();
        }

        public Task<Doctor> Get(int id)
        {
            var doctor = _context.Doctors.FirstOrDefaultAsync(e => e.DoctorId == id);
            return doctor;
        }

        public async Task<IEnumerable<Doctor>> Get()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors;
        }

        public async Task<Doctor> Update(Doctor entity)
        {
            var doctor = await Get(entity.DoctorId);
            if (doctor != null)
            {
                _context.Update(entity);
                _context.SaveChanges(true);
                return doctor;
            }
            throw new NoDoctorExcemption();
        }
    }
}
