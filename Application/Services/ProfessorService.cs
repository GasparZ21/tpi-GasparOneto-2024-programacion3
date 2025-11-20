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
    public class ProfessorService
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorService(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<Professor> GetById(int id)
        {
            try
            {
                return await _professorRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener el professor por id.", ex);
            }
        }
        public async Task AddProfessor(ProfessorDto professorDto)
        {
            var professor = new Professor(professorDto.Id,professorDto.Name, professorDto.Subject);

            await _professorRepository.Add(professor);
        }
        public async Task DeleteByIdAsync(int id)
        {
            var professor = await _professorRepository.GetByIdAsync(id);
            if (professor == null)
            {
                throw new KeyNotFoundException($"Professor with ID {id} not found.");
            }

            await _professorRepository.DeleteAsync(professor);
        }
        public async Task<Professor> UpdateAsync(int id, Professor updatedProfessor)
        {
            if (updatedProfessor == null)
            {
                throw new ArgumentNullException(nameof(updatedProfessor), "The updated assignment cannot be null.");
            }

            if (id != updatedProfessor.Id)
            {
                throw new ArgumentException("ID mismatch between the request and the assignment object.");
            }

            return await _professorRepository.Update(updatedProfessor);

        }
    }
}
