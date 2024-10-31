using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class ProfessorRepository : BaseRepository<Assignment>, IProfessorRepository
    {
        private readonly ApplicationDbContext _context;
        public ProfessorRepository(ApplicationDbContext context) : base(context)
        {
            {
                _context = context;
            }

            public Professor Add(Assignment assignment)
            {
                _context.Assignments.Add(assignment);
                _context.SaveChanges();
                return assignment;
            }

            public Professor Delete(Assignment assignment)
            {
                _context.Assignments.Remove(assignment);
                _context.SaveChanges();
                return assignment;
            }

            public Professor? GetBySubject(string subject)
            {
                return _context.Professors.FirstOrDefault(u => u.subject == subject);
            }
        }
    }
}
