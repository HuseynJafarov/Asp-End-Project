using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Services.Interfaces
{
        public interface IEmailService
        {
            void Send(string to, string subject, string html, string from = null);
        }
}
