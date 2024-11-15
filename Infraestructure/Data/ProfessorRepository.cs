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
    public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
    {
        private readonly ApplicationDbContext _context;
        public ProfessorRepository(ApplicationDbContext context) : base(context)
        {
            {
                _context = context;
            } 
        }

            public Task Professor Add(Assignment assignment)
            {
                _context.Assignments.Add(assignment);
                _context.SaveChanges();
                return assignment;
            }

            public Task Professor Delete(Professor professor)
            {
                _context.Professor.Remove(professor);
                _context.SaveChanges();
                return professor;
            }

            public Professor GetById(int id)
            {
                return _context.Professors.FirstOrDefault(u => u.Id == id);
            }
        }
    }
}
