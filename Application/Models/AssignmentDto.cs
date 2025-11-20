using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class AssignmentDto
    {
        public required int Id { get; set; }
        public string Instruction {  get; set; }= string.Empty;
        public required bool Status { get; set; }
        public required string Subject { get; set; }=string.Empty;

        public int StudentId { get; set; }

        public int ProfessorId { get; set; }
    }
}
