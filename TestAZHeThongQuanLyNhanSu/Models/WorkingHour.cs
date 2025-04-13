namespace TestAZHeThongQuanLyNhanSu.Models
{
    public class WorkingHours
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int TimeSlotId { get; set; }
        public DateTime WorkDate { get; set; }
        public Employee Employee { get; set; } 
        public TimeSlot TimeSlot { get; set; }
    }

}
