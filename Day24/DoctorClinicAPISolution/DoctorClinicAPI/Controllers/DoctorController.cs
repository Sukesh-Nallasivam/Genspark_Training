using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorClinicAPI.Interfaces;
using DoctorClinicAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllDoctors();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctorById(int id)
        {
            var doctor = await _doctorService.GetDoctorById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<ActionResult<Doctor>> AddNewDoctor([FromBody] Doctor doctor)
        {
            try
            {
                var newDoctor = await _doctorService.AddNewDoctor(doctor);
                return CreatedAtAction(nameof(GetDoctorById), new { id = newDoctor.DoctorId }, newDoctor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctorExperience(int id, [FromBody] int experience)
        {
            try
            {
                await _doctorService.UpdateDoctorExperience(id, experience);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Speciality/{speciality}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctorsBySpeciality(string speciality)
        {
            var doctors = await _doctorService.GetDoctorsBySpeciality(speciality);
            if (doctors == null)
            {
                return NotFound();
            }
            return Ok(doctors);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Doctor>> DeleteDoctor(int id)
        {
            try
            {
                var deletedDoctor = await _doctorService.DeleteDoctor(id);
                if (deletedDoctor == null)
                {
                    return NotFound();
                }
                return Ok(deletedDoctor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
