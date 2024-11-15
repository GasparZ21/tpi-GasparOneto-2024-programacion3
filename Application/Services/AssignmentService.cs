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
 
        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;

        }

        public async Task AddAssignment (AssignmentCreateDto assignmentDTO)
        {
            var assignment = new Assignment (assignmentDTO.Instruction, assignmentDTO.Status, assignmentDTO.Subject);

           await _assignmentRepository.Add(assignment);
        }
        public async Task<Assignment> GetBySubject(string subject)
        {
             if (string.IsNullOrEmpty(subject)) {  
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
        public Task DeleteById(int id)
        {
            
            
            return _assignmentRepository.Delete(id);
        }
            
    
    }


}
