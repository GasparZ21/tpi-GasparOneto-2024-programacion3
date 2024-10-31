using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    internal class ProfessorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Subject { get; set; } = null!;

        public ICollection<Assignment> Assignments { get; set; } = null!;

    }
}
