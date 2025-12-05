using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmkNgawi.Data;
using SmkNgawi.Entities;
using SmkNgawi.DTOs;
using System.Security.Cryptography.X509Certificates;


namespace SmkNgawi.Services
{
    public class RegistrationService
    {
        private AppDbContext _context;
public RegistrationService(AppDbContext context)
        {
            // PERBAIKAN UTAMA ANDA DISINI:
            // Kita harus mengisi variable _context dengan kiriman dari luar.
            _context = context; 
        }

        //seeding initial data
        public void SeedData()
        {
            if (!_context.Majors.Any())
            {
                //membuat jurusan tkj
                var tkj = new Major
                {
                    MajorName = "Teknik Komputer dan Jaringan",
                    Code = "Tkj"
                
                };
                _context.Majors.Add(tkj);
                _context.SaveChanges();

                //bikin kelas x tkj
                _context.ClassRooms.Add(new ClassRoom
                {
                    ClassName = "X Tkj 10",
                    MajorId = tkj.Id,
                    GradeLevel = 10
                });

                _context.SaveChanges();
                Console.WriteLine("initial data created");
            }
        }

        
        //fitur penaftaran siswa pakai dto request 
        public void RegisterNewStudent(StudentRegistrationRequest request)
        {
            var newStudent = new Student
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                ClassRoomId = request.TargetClassRoomId,
                RegistrationDate = DateTime.Now
                
            };
            _context.Students.Add(newStudent);
            _context.SaveChanges();


            
        }

        // fitur get all student data dengan merturn list

    public List<StudentDetailResponse> GetAllStudents()
{
    // 1. Ambil data Entity dari Database
    var students = _context.Students
        .Include(s => s.ClassRoom)
        .ThenInclude(c => c.Major)
        .ToList();

    // 2. LAKUKAN MAPPING (Entity -> DTO)
    // Kita ubah bentuk 'Student' menjadi 'StudentDetailResponse'
    var dtoList = students.Select(s => new StudentDetailResponse
    {
        Id = s.Id,
        FullName = $"{s.FirstName} {s.LastName}",
        ClassName = s.ClassRoom?.ClassName ?? "Belum Ada Kelas",
        MajorName = s.ClassRoom?.Major?.MajorName ?? "-",
        RegistrationDate = s.RegistrationDate
    }).ToList();

    // 3. Kembalikan list DTO
    return dtoList;
}



        //fitur show student dengan dto responses
        public void ShowAllStudents()
        {
            //load the studuendt table dari student kelas dan jurusan
            var students = _context.Students
                .Include(s => s.ClassRoom)
                .ThenInclude(c => c.Major)
                .ToList();

            foreach (var student in students)
            {
                var dto = new StudentDetailResponse
                {
                    Id = student.Id,
                    FullName = $"{student.FirstName} {student.LastName}",
                    ClassName = student.ClassRoom.ClassName,
                    MajorName = student.ClassRoom.Major.MajorName,
                    RegistrationDate = student.RegistrationDate


                };
                Console.WriteLine($"{dto.Id} {dto.FullName} {dto.ClassName} {dto.MajorName} {dto.RegistrationDate}");   
            }
        }

    }

}