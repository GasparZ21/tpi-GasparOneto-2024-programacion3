using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IProfessorRepository _professorRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository, IStudentRepository studentRepository, IProfessorRepository professorRepository)
        {
            _assignmentRepository = assignmentRepository;
            _studentRepository = studentRepository;
            _professorRepository = professorRepository;
            
        }

        public async Task AddAssignment(AssignmentDto assignmentDTO)
        {
            var student = await _studentRepository.GetByIdAsync(assignmentDTO.StudentId);
            var professor = await _professorRepository.GetByIdAsync(assignmentDTO.ProfessorId);

            Assignment assignment = new Assignment(
                assignmentDTO.Instruction,
                assignmentDTO.Status,
                assignmentDTO.Subject,
                student,
                professor
            );

            await _assignmentRepository.Add(assignment);
        }
        public async Task<List<Assignment>> GetBySubject(string subject)
        {
            if (string.IsNullOrEmpty(subject))
            {
                throw new ArgumentException("Subject cannot be null or empty", nameof(subject));
            }
            try
            {
                return await _assignmentRepository.GetBySubject(subject);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener el Assignment por subject.", ex);
            }
        }
        public async Task DeleteById(int id)
        {
            var assignment = await _assignmentRepository.GetById(id);

            await _assignmentRepository.Delete(assignment);
        }
        public async Task<Assignment> UpdateAsync(int id, Assignment updatedAssignment)
        {
            if (updatedAssignment == null)
            {
                throw new ArgumentNullException(nameof(updatedAssignment), "The updated assignment cannot be null.");
            }

            if (id != updatedAssignment.Id)
            {
                throw new ArgumentException("ID mismatch between the request and the assignment object.");
            }

            return await _assignmentRepository.Update(updatedAssignment);

        }

    }
}
