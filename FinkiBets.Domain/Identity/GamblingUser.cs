using FinkiBets.Domain.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinkiBets.Domain.Identity
{
    public class GamblingUser : IdentityUser
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]  
        public string LastName { get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
        public double accountBalance { get; set; }
        public ICollection<Ticket> tickets;
    }
}
