using System.ComponentModel.DataAnnotations;

namespace SmkNgawi.DTOs
{
    //menambahkan jurusan
    public class CreateMajorRequest
    {
        [Required]
        public string? MajorName{get; set;}
        
        [Required]
        public string? Code{get; set;}
    
    }

    //dto for add class 
    public class CreateClassRequest
    {
        [Required]
        public string? ClassName{get; set;}
        
        [Required]
        public int MajorId{get; set;}
        
        [Required]
        public int GradeLevel{get; set;}
    }
    //dropdown dto
    public class MajorDropdownDto
    {
        public int Id{get; set;}
        public string Name{get; set;}
    }


}
