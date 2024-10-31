using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Professor : User
    {
        public string subject { get; set; } = null!;
        public ICollection<Assignment> assignments { get; set; } = null!;

    }
}
