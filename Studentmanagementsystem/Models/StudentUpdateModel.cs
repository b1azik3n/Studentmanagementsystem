namespace Studentmanagementsystem.Models
{
    public class StudentUpdateModel
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public int Percentage { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Department { get; set; }
    }
}
