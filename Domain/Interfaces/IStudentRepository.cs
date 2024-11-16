using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> GetByIdAsync(int id);
        Task<Student> Add(Student student);
        Task<Student> DeleteAsync(Student student);
        Task<Student> Update(Student student);
    }
}
