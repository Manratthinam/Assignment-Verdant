using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.requestEntities.Auth
{
    public class LogInEntity
    {
        [Required(ErrorMessage ="Enter your email")]
        
        public string Email { get; set; }
        [Required(ErrorMessage ="Enter your password")]
        public string Password { get; set; }
    }
}
