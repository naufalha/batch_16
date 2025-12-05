namespace SmkNgawi.DTOs
{
    public class StudentRegistrationRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int TargetClassRoomId { get; set; } // User memilih ID Kelas (Misal: ID 1 untuk X-TKJ-1)
        public DateTime RegistrationDate { get; set; }
    
    }
}