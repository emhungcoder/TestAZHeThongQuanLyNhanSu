namespace TestAZHeThongQuanLyNhanSu.Models
{
    public class WorkingHours
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int TimeSlotId { get; set; }
        public DateTime WorkDate { get; set; }

        // Liên kết với bảng Employee
        public Employee Employee { get; set; }

        // Liên kết với bảng TimeSlot
        public TimeSlot TimeSlot { get; set; }
    }

}
