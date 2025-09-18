using CAS.Application.Contract;
using CilinicAppointmentSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CilinicAppointmentSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            this._doctorService = doctorService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateDoctor(CreateDoctorModel createDoctor,
            CancellationToken cancellationToken)
        {
            var dto = createDoctor.MapToDto();
            var id = await _doctorService.Create(dto,cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = id }, new { 
                id = id, 
                name = dto.Name,
                lastName = dto.LastName,
                speciality = dto.Speciality,
                nationalCode = dto.NationalCode
            });        

        }   

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(id, out var guid))
                return BadRequest("Invalid ID format");

            try
            {
                var doctor = await _doctorService.GetById(guid, cancellationToken);
                return Ok(doctor);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

       
    }
}