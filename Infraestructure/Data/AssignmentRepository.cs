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
            public Assignment Add(Assignment assignment)
            {
                _context.Assignments.Add(assignment);
                _context.SaveChanges();
                return assignment;
            }


            public async Task<Assignment> Delete(Assignment assignment)
            {
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
    }
}
