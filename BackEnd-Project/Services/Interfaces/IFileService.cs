using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Services.Interfaces
{
        public interface IFileService
        {
            string ReadFile(string path, string template);
        }
}
