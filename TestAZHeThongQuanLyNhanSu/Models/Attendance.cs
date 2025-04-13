namespace TestAZHeThongQuanLyNhanSu.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; } = null!;
        public Employee Employee { get; set; } = null!;
        public DateTime ClockInTime { get; set; }
        public DateTime? ClockOutTime { get; set; }
        
    }
}
    