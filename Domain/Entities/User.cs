﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Password {  get; set; } = null!;
        public string  Rol { get; set; } = null!;
    }
}
