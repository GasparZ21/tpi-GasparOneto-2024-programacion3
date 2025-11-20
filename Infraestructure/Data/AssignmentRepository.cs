using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class AssignmentRepository : BaseRepository<Assignment>, IAssignmentRepository
    {
        private readonly ApplicationDbContext _context;
        public AssignmentRepository(ApplicationDbContext context) : base(context)
        {
            {
                _context = context;
            }
        }

        public async Task<Assignment> GetById(int id)
        {
            var assignment= await _context.Assignments.FirstOrDefaultAsync(x => x.Id == id);
            
            if (assignment == null) {
                throw new KeyNotFoundException($"Assignment with id {id} not found.");
            }
            
            return assignment;
        }

            public async Task <Assignment> Add(Assignment assignment)
            {
                _context.Assignments.Add(assignment);
                await _context.SaveChangesAsync();
                return assignment;
            }


            public async Task<Assignment> Delete(Assignment assignment)
            {
                if (assignment == null) throw new InvalidOperationException("No s eencontro el assignment");

            if (assignment.Status)
                {
                    _context.Assignments.Remove(assignment);
                    await _context.SaveChangesAsync();
                    return assignment;
                }
                else { 
                    throw new InvalidOperationException("Assignment no se puede eliminar");
                 }
            }

        public async Task<List<Assignment>> GetBySubject(string subject)
        {

            return await _context.Assignments.Where(a => a.Subject == subject).ToListAsync();
        }

        public async Task<Assignment> Update(Assignment assignment) 
        {

            if(assignment == null)
            {
                throw new ArgumentNullException(nameof(assignment), "The assignment cannot be null.");
            }

            var existingAssignment = await _context.Assignments.FindAsync(assignment.Id);
            if (existingAssignment == null)
            {
                throw new KeyNotFoundException($"No assignment found with ID {assignment.Id}");
            }

            existingAssignment.Instruction = assignment.Instruction;
            existingAssignment.Status = assignment.Status;
            existingAssignment.Subject = assignment.Subject;

            await _context.SaveChangesAsync();

            return existingAssignment;
        }
    }
}
