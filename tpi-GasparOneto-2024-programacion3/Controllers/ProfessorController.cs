using Application.Models;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace tpi_GasparOneto_2024_programacion3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly ProfessorService _professorservice;
        public ProfessorController(ProfessorService professorservice)
        {
            _professorservice = professorservice;
        }
        [HttpGet("{id}")]
        public async Task <ActionResult<ProfessorDto>> GetByIdAsync(int id)
        {

            try
            {

               var professor = await _professorservice.GetById(id);

                return Ok(new ProfessorDto
                {
                    Id = professor.Id,
                    Subject = professor.Subject,
                    Assignments = professor.assignments,
                    Name = professor.Name,
                });
            }

            catch
            {
                return NotFound();
            }

        }
        [HttpPost]
        public ActionResult<ProfessorDto> CreateProfessors([FromBody] ProfessorDto professorDto)
        {

            try
            {
                var newProfessor = _professorservice.AddProfessor(professorDto);
                return Ok(newProfessor);
            }
            catch
            {

                return BadRequest();

            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {

            try
            {
              await _professorservice.DeleteByIdAsync(id);
                return Ok();
            }

            catch
            {
                return BadRequest();
            }

        }
        [HttpPut]
        public async Task<IActionResult> UpdateAssignment(int id, [FromBody] Professor updatedProfessor)
        {
            if (updatedProfessor == null)
            {
                return BadRequest("The assignment object cannot be null.");
            }

            try
            {
                var result = await _professorservice.UpdateAsync(id, updatedProfessor);

                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
