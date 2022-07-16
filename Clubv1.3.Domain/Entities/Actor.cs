using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubv1._3.Domain.Entities
{
    public class Actor
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime? DeceaseDate { get; set; }
    }
}
