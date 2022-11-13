using EmbryoFrontToBack.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Models.ContactUs
{
    public class TellUs:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
