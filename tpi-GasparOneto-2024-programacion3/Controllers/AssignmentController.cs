using Application.Models;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace tpi_GasparOneto_2024_programacion3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly AssignmentService _assignmentService;

        public AssignmentController(AssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet]
        public ActionResult<AssignmentDto> GetBySubject(string subject)
        {

            try
            {

                return Ok(_assignmentService.GetBySubject(subject));
            }

            catch
            {
                return NotFound();
            }

        }

        [HttpPost]
        public ActionResult<AssignmentDto> CreateAssignments([FromBody] AssignmentDto assignmentCreateDto)
        {

            try
            {
                var newAssignment = _assignmentService.AddAssignment(assignmentCreateDto);
                return Ok(newAssignment);
            }
            catch
            {

                return BadRequest();
                
            }

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAssignment(AssignmentDto assignmentToDelete) {

            try
            {
                await _assignmentService.DeleteById(assignmentToDelete.Id);
                return Ok();
            }

            catch 
            { 
                return BadRequest();
            }
        
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssignment(int id, [FromBody] Assignment updatedAssignment)
        {
            if (updatedAssignment == null)
            {
                return BadRequest("The assignment object cannot be null."); 
            }

            try
            {
                var result = await _assignmentService.UpdateAsync(id, updatedAssignment);

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
