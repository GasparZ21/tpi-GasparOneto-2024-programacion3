using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ProfessorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;

        public ICollection<Assignment> Assignments { get; set; } = null!;

    }
}
