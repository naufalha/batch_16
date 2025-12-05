using Microsoft.AspNetCore.Mvc;
using SmkNgawi.DTOs;
using SmkNgawi.Services;

namespace SmkNgawi.Controllers
{
    public class StudentController : Controller
    {
        private readonly RegistrationService _service;

        // Constructor Injection
        // ASP.NET otomatis memasukkan service yang sudah didaftarkan di Program.cs
        public StudentController(RegistrationService service)
        {
            _service = service;
        }

        // GET: /Student
        public IActionResult Index()
        {
            // Pastikan database ada isinya (Shortcut untuk tutorial)
            _service.SeedData(); 

            // Ambil data dari Service
            var data = _service.GetAllStudents(); // <-- Anda perlu update Service agar me-return List, bukan void print console
            
            // Kirim data ke View (Layar)
            return View(data);
        }

        // GET: /Student/Create (Menampilkan Form)
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create (Menerima Input Form)
        [HttpPost]
        public IActionResult Create(StudentRegistrationRequest request)
        {
            if (ModelState.IsValid)
            {
                _service.RegisterNewStudent(request);
                return RedirectToAction("Index"); // Kembali ke list
            }
            return View(request); // Jika error, tampilkan form lagi
        }
    }
}