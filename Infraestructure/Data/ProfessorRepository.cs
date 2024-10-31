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

            public Assignment Add(Assignment assignment)
            {
                _context.Assignments.Add(assignment);
                _context.SaveChanges();
                return assignment;
            }

            public Assignment Delete(Assignment assignment)
            {
                _context.Assignments.Remove(assignment);
                _context.SaveChanges();
                return assignment;
            }

            public Assignment? GetByStatus(bool status)
            {
                return _context.Assignments.FirstOrDefault(u => u.Status == status);
            }
        }
    }
}
