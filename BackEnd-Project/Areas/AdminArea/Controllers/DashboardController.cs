using BackEnd_Project.Helpers.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Areas.AdminArea.Controllers
{
    public class DashboardController : Controller
    {
        [Area("AdminArea")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
