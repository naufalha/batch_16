using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmkNgawi.DTOs;
namespace SmkNgawi.Entities
{
    public class ClassRoom
    {
        [Key]
        public int Id{get; set;}
        
        public string ClassName{get ; set ;}

        //foreign key ke major
        public int MajorId{get; set;}
        public int GradeLevel{get; set;}


        //relation
        public Major Major{get; set;}

        //relasi satu kelas ke banyak siswa
        public List<Student> Students{get; set;}

    }
}