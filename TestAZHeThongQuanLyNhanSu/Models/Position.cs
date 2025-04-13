namespace TestAZHeThongQuanLyNhanSu.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // Sử dụng decimal thay vì double
        public decimal BasicSalary { get; set; }
        public decimal Allowance { get; set; }
        public TimeSpan StartTime { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
