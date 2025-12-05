using Microsoft.AspNetCore.Mvc;
using SmkNgawi.DTOs;
using SmkNgawi.Services;
using SmkNgawiWeb.Services;

namespace SmkNgawiWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        // Tampilkan Form Tambah Jurusan
        public IActionResult AddMajor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMajor(CreateMajorRequest request)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddMajor(request);
                return RedirectToAction("Index", "Student"); // Kembali ke home setelah sukses
            }
            return View(request);
        }

        // Tampilkan Form Tambah Kelas
        public IActionResult AddClass()
        {
            // Kita kirim daftar jurusan ke View agar bisa jadi Dropdown
            ViewBag.Majors = _adminService.GetMajorsForDropdown();
            return View();
        }

        [HttpPost]
        public IActionResult AddClass(CreateClassRequest request)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddClass(request);
                return RedirectToAction("Index", "Student");
            }
            // Kalau gagal, load lagi dropdown-nya
            ViewBag.Majors = _adminService.GetMajorsForDropdown();
            return View(request);
        }
    }
}