using System;
using System.Collections.Generic;
using System.Linq;
using SmkNgawi.Data;
using SmkNgawi.DTOs;
using SmkNgawi.Entities;

namespace SmkNgawiWeb.Services
{
    public class AdminService
    {
        private readonly AppDbContext _context;

        public AdminService(AppDbContext context)
        {
            _context = context;
        }

        // 1. FITUR TAMBAH JURUSAN
        public void AddMajor(CreateMajorRequest request)
        {
            // Validasi: Cek apakah kode jurusan sudah ada?
            bool exists = _context.Majors.Any(m => m.Code == request.Code);
            if (exists)
            {
                throw new Exception($"Jurusan dengan kode {request.Code} sudah ada!");
            }

            var newMajor = new Major
            {
                MajorName = request.MajorName,
                Code = request.Code.ToUpper() // Paksa huruf besar
            };

            _context.Majors.Add(newMajor);
            _context.SaveChanges();
        }

        // 2. FITUR TAMBAH KELAS
        public void AddClass(CreateClassRequest request)
        {
            // Validasi: Pastikan Jurusan yang dipilih Valid
            bool majorExists = _context.Majors.Any(m => m.Id == request.MajorId);
            if (!majorExists)
            {
                throw new Exception("Jurusan tidak ditemukan.");
            }

            var newClass = new ClassRoom
            {
                ClassName = request.ClassName,
                GradeLevel = request.GradeLevel,
                MajorId = request.MajorId
            };

            _context.ClassRooms.Add(newClass);
            _context.SaveChanges();
        }

        // 3. FITUR AMBIL DATA JURUSAN (Untuk Dropdown)
        // Kita butuh ini agar saat bikin kelas, Admin bisa milih Jurusan yang ada
        public List<MajorDropdownDto> GetMajorsForDropdown()
        {
            return _context.Majors
                .Select(m => new MajorDropdownDto
                {
                    Id = m.Id,
                    Name = $"{m.MajorName} ({m.Code})"
                })
                .ToList();
        }
    }
}