using BackEnd_Project.Data;
using BackEnd_Project.Models;
using BackEnd_Project.Models.ContactUs;
using BackEnd_Project.Services;
using BackEnd_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly LayoutService _layoutService;

        public ContactUsController(AppDbContext context, LayoutService layoutService)
        {
            _context = context;
            _layoutService = layoutService;
        }

        public async Task<IActionResult> Index()
        {
            Dictionary<string, string> settingDatas = await _layoutService.GetDatasFromSetting();

            Info infos = await _context.Infos.Where(m=> m.IsDeleted == false).FirstOrDefaultAsync();


            ContactUsVM model = new ContactUsVM
            {
                Settings = settingDatas,
                Infos = infos,
                TellUs = new TellUs()
            };
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(TellUs tellUs)
        {
            try
            {
              
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Index));
                }


                bool isExist = await _context.TellUs.AnyAsync(m => m.Name.Trim() == tellUs.Name.Trim() && 
                m.Email.Trim() == tellUs.Email.Trim() &&
                m.Message.Trim() == tellUs.Message.Trim() &&
                m.Subject.Trim() == tellUs.Subject.Trim() &&
                m.Phone== tellUs.Phone);

                if (isExist)
                {
                    ModelState.AddModelError("Name", "Subject already exist");
                    return View();
                }


                await _context.TellUs.AddAsync(tellUs);

                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }

            
        }
    }
}
