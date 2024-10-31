using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        public AssignmentSevice(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }
    
    }


}
