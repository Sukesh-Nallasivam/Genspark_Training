using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicDALLibrary.Models;
namespace ClinicDALLibrary
{
    internal class PatientRepositoryClass : IRepository<int, Patient>
    {
        readonly Dictionary<int, Patient> _patients;
        public PatientRepositoryClass()
        {
            _patients = new Dictionary<int, Patient>();
        }
        int GeneratePatientId()
        {
            if (_patients.Count == 0)
            {
                return 1;
            }
            int id = _patients.Keys.Max();
            return ++id;
        }
        public Patient Add(Patient item)
        {
            if (_patients.ContainsValue(item))
            {
                return null;
            }
            item.Id = GeneratePatientId();

            _patients.Add(item.Id, item);
            return item;
        }

        public Patient Delete(int key)
        {
            if (_patients.ContainsKey(key))
            {
                var appoinment = _patients[key];
                _patients.Remove(key);
                return appoinment;
            }
            return null;
        }

        public Patient Get(int key)
        {
            return _patients.ContainsKey(key) ? _patients[key] : null;
        }

        public List<Patient> GetAll()
        {
            if (_patients.Count == 0)
                return null;
            return _patients.Values.ToList();
        }

        public Patient Update(Patient item)
        {
            if (_patients.ContainsKey(item.Id))
            {
                _patients[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
