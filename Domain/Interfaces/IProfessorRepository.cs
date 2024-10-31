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
        Task<IEnumerable<Assignment>>GetByStatus(bool status);
        Task<Assignment> Add(Assignment assignment);
        Task<Assignment> Delete(int status);
    }
}
