using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAssignmentRepository
    {
        public List<Assignment> GetBySubject(string subject);
        Task<Assignment> Add(Assignment assignment);
        Task<Assignment> Delete(int status);
        Task<Assignment> Delete(Assignment assignment);
    }
}
