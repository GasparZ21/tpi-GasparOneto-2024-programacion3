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
    public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
    {
        private readonly ApplicationDbContext _context;
        public ProfessorRepository(ApplicationDbContext context) : base(context)
        {
            {
                _context = context;
            }
        }

        public async Task<Professor> Add(Professor professor)
        {
            _context.Professors.Add(professor);
            await _context.SaveChangesAsync();
            return professor;
        }


        public async Task<Professor> DeleteAsync(Professor professor)
        {
            if (professor == null)
            {
                throw new ArgumentNullException(nameof(professor), "The professor object cannot be null.");
            }

            
            _context.Professors.Remove(professor);
            await _context.SaveChangesAsync(); 

            return professor;
        }

        public async Task<Professor> GetByIdAsync(int id)
        {
            var professor = await _context.Professors.FirstOrDefaultAsync(p => p.Id == id);
            if (professor == null)
            {
                throw new KeyNotFoundException($"No professor found with ID {id}");
            }
            return professor;
        }
        public async Task<Professor> Update(Professor professor)
        {

            if (professor == null)
            {
                throw new ArgumentNullException(nameof(professor), "The assignment cannot be null.");
            }

            var existingProfessor = await _context.Professors.FindAsync(professor);
            if (existingProfessor == null)
            {
                throw new KeyNotFoundException($"No assignment found with ID {professor.Id}");
            }

            existingProfessor.Id = professor.Id;
            existingProfessor.Name = professor.Name;
            existingProfessor.Subject = professor.Subject;

            await _context.SaveChangesAsync();

            return existingProfessor;
        }
    }
  }

