using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
       

        public User(int id, string name, string rol) {
            Id = id;
            Name = name;
            Rol = rol;
        
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Password {  get; set; } = string.Empty;
        public string  Rol { get; set; } = string.Empty;
    }
}
