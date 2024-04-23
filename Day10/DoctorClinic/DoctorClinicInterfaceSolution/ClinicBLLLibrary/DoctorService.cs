using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ClinicDALLibrary;
using ClinicModelLibrary;

namespace ClinicBLLLibrary
{
    public class DoctorService : IDoctorService
    {
        private readonly DoctorRepositoryClass _doctorRepository;

        public DoctorService(DoctorRepositoryClass doctorRepository)
        {
            _doctorRepository = doctorRepository;
            
            
        }

        public void AddDoctor(Doctor doctor)
        {
            
            try
            {
                _doctorRepository.Add(doctor);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding Doctor {ex.Message}");
            }
        }

        public void UpdateDoctor(Doctor doctor)
        {
            
            try
            {
                _doctorRepository.Update(doctor);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating Doctor {ex.Message}");
            }
        }

        public void DeleteDoctor(int id)
        {
            try
            {
                _doctorRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting Doctor {ex.Message}");
            }
        }

        public Doctor GetDoctorById(int id)
        {
            
            try
            {
                return _doctorRepository.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting Doctor {ex.Message}");
            }
        }

        public Doctor GetDoctorByName(string name)
        {
            try
            {
                return _doctorRepository.GetName(name);
            }
            catch(Exception ex)
            {
                throw new Exception($"Error in finding name");
            }
        }
    }
}
