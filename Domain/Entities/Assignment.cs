using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Assignment
    {
        public string instruction { get; set; } = null!;
        public bool Status { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; } = null!;

    }
}
