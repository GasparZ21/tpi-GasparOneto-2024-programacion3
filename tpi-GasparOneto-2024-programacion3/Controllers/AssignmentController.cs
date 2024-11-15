using Application.Models;
using Application.Services;
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
        public ActionResult<AssignmentCreateDto> GetBySubject(string subject)
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
        public ActionResult<AssignmentCreateDto> CreateAssignments([FromBody] AssignmentCreateDto assignmentCreateDto)
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
        public ActionResult DeleteAssignment(AssignmentCreateDto assignmentToDelete) {

            try
            {
                _assignmentService.DeleteById(assignmentToDelete.Id);
                return Ok();
            }

            catch 
            { 
                return BadRequest();
            }
        
        }

    } 
    
}
