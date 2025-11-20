using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Professor : User
    {
        public Professor(int id, string name, string subject)  : base(id, name, User.Professor)
        {
            Id = id;
            Name = name;
            Subject= subject;
        }

        public string Subject { get; set; } = string.Empty;
        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    }
}
