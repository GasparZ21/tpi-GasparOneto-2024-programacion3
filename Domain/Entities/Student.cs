using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student : User
    {

        public Student(int id, string name, int courseSection) : base(id, name, User.Student)
        {
            CourseSection = courseSection;
        }

        public int CourseSection {  get; set; }
        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}
