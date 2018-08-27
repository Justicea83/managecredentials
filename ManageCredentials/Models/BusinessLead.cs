using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManageCredentials.Models
{
    public class BusinessLead
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        [Display(Name = "NL / GH")]
        public CountryName Country { get; set; }
        public Phases Phase { get; set; }
        public string Contact { get; set; }
        [Required]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public enum Phases
        {
            First = 1,
            Second = 2,
            Third = 3,
            Fourth = 4,
            Fifth = 5,
        }
        public enum CountryName {
            NL ,
            GH
        }
    }
}
