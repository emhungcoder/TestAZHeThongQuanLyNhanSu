namespace TestAZHeThongQuanLyNhanSu.Models
{
    public class RewardDisciplinary
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; } 
        public Employee Employee { get; set; } 

        public DateTime Date { get; set; } 
        public string Type { get; set; } 
        public string Description { get; set; } 
        public decimal Amount { get; set; } 
    }
}
