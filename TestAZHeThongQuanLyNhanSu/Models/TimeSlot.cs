namespace TestAZHeThongQuanLyNhanSu.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        // Quan hệ với WorkingHours
        public ICollection<WorkingHours> WorkingHours { get; set; } = new List<WorkingHours>();
    }

}
