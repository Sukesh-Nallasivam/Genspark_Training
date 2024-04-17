using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicModelLibrary;

namespace ClinicDALLibrary
{
    public class AppointmentRepositoryClass : IRepository<int, Appointment>
    {

        readonly Dictionary<int, Appointment> _appoinments;

        public AppointmentRepositoryClass()
        {
            _appoinments = new Dictionary<int, Appointment>();
        }
        int GenerateAppointmentId()
        {
            if (_appoinments.Count == 0)
            {
                return 1;
            }
            int id = _appoinments.Keys.Max();
            return ++id;
        }
        public Appointment Add(Appointment item)
        {
            if (_appoinments.ContainsValue(item))
            {
                return null;
            }
            item.AppointmentId = GenerateAppointmentId();
            //if (_appoinments.ContainsValue(item.PatientId)
            //{
            //    return null;
            //}
            _appoinments.Add(item.AppointmentId, item); 
            return item;
        }

        public Appointment Delete(int key)
        {
            if (_appoinments.ContainsKey(key))
            {
                var appoinment = _appoinments[key];
                _appoinments.Remove(key);
                return appoinment;
            }
            return null;
        }

        public Appointment Get(int key)
        {
            return _appoinments.ContainsKey(key) ? _appoinments[key] : null;
        }

        public List<Appointment> GetAll()
        {
            if (_appoinments.Count == 0)
                return null;
            return _appoinments.Values.ToList();
        }

        public Appointment Update(Appointment item)
        {
            if (_appoinments.ContainsKey(item.AppointmentId))
            {
                _appoinments[item.AppointmentId] = item;
                return item;
            }
            return null;
        }
    }
}
