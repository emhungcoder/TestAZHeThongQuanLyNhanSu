using Microsoft.AspNetCore.Identity;

namespace TestAZHeThongQuanLyNhanSu.Models
{
    public class Employee : IdentityUser
    {
        public string FullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string? Address { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; } = true;

        public int PositionId { get; set; }
        public Position? Position { get; set; }

      
        public decimal BasicSalary { get; set; }
        public decimal Allowance { get; set; }

        public ICollection<WorkingHours> WorkingHours { get; set; } = new List<WorkingHours>();
    }

}
