using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModelLibrary
{
    public class Doctor:IDoctor
    {
        [Key]
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Speciality { get; set; }
        public double Contact { get; set; }
        public string ConsultingHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doctorId"></param>
        /// <param name="doctorName"></param>
        /// <param name="speciality"></param>
        /// <param name="contact"></param>
        /// <param name="consultingHours"></param>
        public Doctor(int doctorId, string doctorName, string speciality, double contact, string consultingHours)
        {
            DoctorId = doctorId;
            DoctorName = doctorName;
            Speciality = speciality;
            Contact = contact;
            ConsultingHours = consultingHours;
        }

        public Doctor()
        {
        }
    }
}
