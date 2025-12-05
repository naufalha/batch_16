using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmkNgawi.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }

        // Foreign Key ke ClassRoom
        // Siswa mendaftar langsung masuk ke Kelas tertentu
        public int ClassRoomId { get; set; }
        
        [ForeignKey("ClassRoomId")]
        public ClassRoom ClassRoom { get; set; }
    }
}