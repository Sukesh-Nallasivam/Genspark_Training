using ClinicModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBLLLibrary
{
    public interface IDoctor
    {
        void AddDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(int id);
        Doctor GetDoctorById(int id);
        
    }
}
