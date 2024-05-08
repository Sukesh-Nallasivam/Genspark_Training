using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModelLibrary
{
    public class Patient:IPatient 
    {
        [Key]
        public int Id { get; set; }
        public int PatientName { get; set; }
        public int PatientAge { get; set; }
        public string[] PatientMedicalHistory { get; set; }
        public string[] PreviousConsultants { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patientName"></param>
        /// <param name="patientAge"></param>
        /// <param name="patientMedicalHistory"></param>
        /// <param name="previousConsultants"></param>
        public Patient(int id, int patientName, int patientAge, string[] patientMedicalHistory, string[] previousConsultants)
        {
            Id = id;
            PatientName = patientName;
            PatientAge = patientAge;
            PatientMedicalHistory = patientMedicalHistory;
            PreviousConsultants = previousConsultants;
        }

        public Patient()
        {
        }
    }
}
