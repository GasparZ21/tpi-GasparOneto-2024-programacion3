using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Assignment
    {
        public Assignment(string instruction, bool status, string subject)
        {
            Instruction = instruction;
            Status = status;
            Subject = subject;

        }
        public int Id {  get; set; }
        public string Instruction { get; set; } = null!;
        public bool Status { get; set; }
        public string Subject {  get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; } = null!;

    }
}
