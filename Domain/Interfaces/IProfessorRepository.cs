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
        Task<IEnumerable<Professor>>GetById(string subject);
        Task<Professor> Add(Professor professor);
        Task<Professor> Delete(int id);
    }
}
