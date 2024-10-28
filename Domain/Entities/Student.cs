using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student : User
    {
        int CourseSection {  get; set; }
        public List<Assignment> assignments { get; set; } = null!;
    }
}
