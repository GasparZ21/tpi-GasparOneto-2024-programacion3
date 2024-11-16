using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProfessorRepository
    {
        Task<Professor> GetByIdAsync(int id);
        Task<Professor> Add(Professor professor);
        Task<Professor> DeleteAsync(Professor professor);
        Task<Professor> Update(Professor professor);

    }
}
