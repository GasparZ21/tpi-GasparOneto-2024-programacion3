﻿using Application.Models;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace tpi_GasparOneto_2024_programacion3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetByIdAsync(int id)
        {
            try
            {
                var student = await _studentService.GetById(id);

                return Ok(new StudentDto
                {
                    Id = student.Id,
                    Name = student.Name,
                    CourseSection = student.CourseSection,
                });
            }

            catch
            {
                return NotFound();
            }

        }
      
        [HttpPost]
        public ActionResult<StudentDto> CreateStudent([FromBody] StudentDto studentDto)
        {

            try
            {
                var newProfessor = _studentService.AddStudent(studentDto);
                return Ok(newProfessor);
            }
            catch
            {

                return BadRequest();

            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {

            try
            {
                await _studentService.DeleteByIdAsync(id);
                return Ok();
            }

            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAssignment(int id, [FromBody] Student updatedStudent)
        {
            if (updatedStudent == null)
            {
                return BadRequest("The assignment object cannot be null.");
            }

            try
            {
                var result = await _studentService.UpdateAsync(id, updatedStudent);

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
