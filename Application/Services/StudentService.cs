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
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> GetById(int id)
        {
            try
            {
                return await _studentRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener el professor por id.", ex);
            }
        }
        public async Task AddStudent(StudentDto studentDto)
        {
            var student = new Student(studentDto.Id, studentDto.Name, studentDto.CourseSection);

            await _studentRepository.Add(student);
        }
        public async Task DeleteByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                throw new KeyNotFoundException($"Student with ID {id} not found.");
            }

            await _studentRepository.DeleteAsync(student);
        }
        public async Task<Student> UpdateAsync(int id, Student updatedStudent)
        {
            if (updatedStudent == null)
            {
                throw new ArgumentNullException(nameof(updatedStudent), "The updated student cannot be null.");
            }

            if (id != updatedStudent.Id)
            {
                throw new ArgumentException("ID mismatch between the request and the student object.");
            }

            return await _studentRepository.Update(updatedStudent);

        }
    }
}
