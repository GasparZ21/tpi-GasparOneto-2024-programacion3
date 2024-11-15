﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class AssignmentCreateDto
    {
        [Required]
        public string Instruction {  get; set; }= string.Empty;

        [Required]
        public bool Status { get; set; }

        [Required]
        public string Subject { get; set; }=string.Empty;
    }
}
