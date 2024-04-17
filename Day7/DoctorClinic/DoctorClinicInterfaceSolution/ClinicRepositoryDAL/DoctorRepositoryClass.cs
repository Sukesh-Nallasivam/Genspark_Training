using ClinicModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDALLibrary
{
    class DoctorRepositoryClass : IRepository<int, Doctor>
    {
        readonly Dictionary<int, Doctor> _doctors;

        public DoctorRepositoryClass()
        {
            _doctors = new Dictionary<int, Doctor>();
        }

        int GenerateDoctorId()
        {
            if (_doctors.Count == 0)
            {
                return 1;
            }
            int id = _doctors.Keys.Max();
            return ++id;
        }
        public Doctor Add(Doctor item)
        {
            if (_doctors.ContainsValue(item))
            {
                return null;
            }
            item.DoctorId = GenerateDoctorId();
            _doctors.Add(item.DoctorId, item);
            return item;
        }

        public Doctor Delete(int key)
        {
            if (_doctors.ContainsKey(key))
            {
                var appoinment = _doctors[key];
                _doctors.Remove(key);
                return appoinment;
            }
            return null;
        }

        public Doctor Get(int key)
        {
            return _doctors.ContainsKey(key) ? _doctors[key] : null;
        }

        public List<Doctor> GetAll()
        {
            if (_doctors.Count == 0)
                return null;
            return _doctors.Values.ToList();
        }

        public Doctor Update(Doctor item)
        {
            if (_doctors.ContainsKey(item.DoctorId))
            {
                _doctors[item.DoctorId] = item;
                return item;
            }
            return null;
        }
    }
}
