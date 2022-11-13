using BackEnd_Project.Models;
using BackEnd_Project.Models.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.ViewModels
{
    public class ContactUsVM
    {
        public Info Infos { get; set; }
        public Dictionary<string, string> Settings { get; set; }
        public TellUs TellUs { get; set; }
    }
}
