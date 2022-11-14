using BackEnd_Project.Data;
using BackEnd_Project.Helpers;
using BackEnd_Project.Models.BlogPage;
using BackEnd_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CustomerController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index() => View(await _context.Customers.Where(m => !m.IsDeleted).Include(m=> m.Socials).ToListAsync());

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerVM customerVM)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                foreach (var photo in customerVM.Photo)
                {
                    if (!photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image type");
                        return View();
                    }
                    if (!photo.CheckFileSize(2000))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image size");
                        return View();
                    }

                }

                foreach (var photo in customerVM.Photo)
                {
                    string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                    string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/blog", fileName);

                    await SaveFile(path, photo);

                    Customer customer = new Customer
                    {
                        Image = fileName,
                        BlogAuthor = customerVM.BlogAuthor,
                        Position = customerVM.Position,
                        Socials = customerVM.Social,
                    };

                    await _context.Customers.AddAsync(customer);
                }


                bool isExist = await _context.Customers.AnyAsync(m => m.BlogAuthor.Trim() == customerVM.BlogAuthor.Trim() &&
                m.Position.Trim() == customerVM.Position.Trim());
 
                if (isExist)
                {
                    ModelState.AddModelError("BlogAuthor Position", "Customer already exist");
                    return View();
                }


                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }

        }


        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id is null) return BadRequest();

                Customer customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);

                if (customer is null) return NotFound();

                return View(customer);

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            Customer customer = await GetByIdAsync(id);

            if (customer == null) return NotFound();

            string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/blog", customer.Image);

            Helper.DeleteFile(path);

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id is null) return BadRequest();

                Customer customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);

                if (customer is null) return NotFound();

                return View(customer);

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(customer);
                }

                if (customer.Photo != null)
                {
                    if (!customer.Photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image type");
                        return View();
                    }

                    if (!customer.Photo.CheckFileSize(200))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image size");
                        return View();
                    }

                    string fileName = Guid.NewGuid().ToString() + "_" + customer.Photo.FileName;

                    Customer dbCustomer = await _context.Customers.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

                    if (dbCustomer is null) return NotFound();

                    if (dbCustomer.BlogAuthor.Trim().ToLower() == customer.BlogAuthor.Trim().ToLower() 
                        && dbCustomer.Position.Trim().ToLower() == customer.Position.Trim().ToLower()
                        && dbCustomer.Photo == customer.Photo)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/blog", fileName);

                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        await customer.Photo.CopyToAsync(stream);
                    }

                    customer.Image = fileName;

                    _context.Customers.Update(customer);

                    await _context.SaveChangesAsync();

                    string dbPath = Helper.GetFilePath(_env.WebRootPath, "assets/img/blog", dbCustomer.Image);

                    Helper.DeleteFile(dbPath);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }



        private async Task SaveFile(string path, IFormFile Singphoto)
        {
            using FileStream stream = new FileStream(path, FileMode.Create);
            await Singphoto.CopyToAsync(stream);
        }

        private async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }
    }
}
