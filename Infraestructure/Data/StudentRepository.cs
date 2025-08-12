using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class StudentRepository:BaseRepository<Student>,IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            {
                _context = context;
            }

        }
        public async Task<Student> Add(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<Student> DeleteAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "The student object cannot be null.");
            }


            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student == null)
            {
                throw new KeyNotFoundException($"No student found with ID {id}");
            }
            return student;
        }
        public async Task<Student> Update(Student student)
        {

            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "The student object cannot be null.");
            }

            var existingStudent = await _context.Students.FindAsync(student);
            if (existingStudent == null)
            {
                throw new KeyNotFoundException($"No assignment found with ID {student.Id}");
            }

            existingStudent.Id = student.Id;
            existingStudent.Name = student.Name;
            existingStudent.Assignments = student.Assignments;

            await _context.SaveChangesAsync();

            return existingStudent;
        }
    }
}
