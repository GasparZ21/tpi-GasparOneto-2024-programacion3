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
        public Task<List<Assignment>> GetBySubject(string subject);
        public Task<Assignment> GetById(int id);
        public Task<Assignment> Add(Assignment assignment);

        public Task<Assignment> Delete(Assignment assignment);

        public Task<Assignment> Update(Assignment assignment);
    }
}
