using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DutchTreats.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Too Long brah less than 250 characters is your limit")]
        public string Message { get; set; }
    }
}
