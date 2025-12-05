using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SmkNgawi.Entities
{
    public class Major
    {
        [Key]
        public int Id{ get; set;}

        [Required]
        public string MajorName{get ; set;}
        public string Code{get; set;}


        //relation
        public List<ClassRoom> ClassRooms{get; set;}
    
    }
}