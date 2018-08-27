using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManageCredentials.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Company Name")]
        public string Company { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        [Display(Name = "NL / GH")]
        public CountryName Country { get; set; }
        [Required]
        [Display(Name ="Contact")]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public enum CountryName
        {
            NL,
            GH
        }
    }
}
