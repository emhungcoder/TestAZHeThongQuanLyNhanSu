namespace TestAZHeThongQuanLyNhanSu.Models
{
    public class RewardDisciplinary
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; } // Foreign key to Employee
        public Employee Employee { get; set; }  // Navigation property

        public DateTime Date { get; set; } // Ngày khen thưởng/ kỹ luật
        public string Type { get; set; } // Loại: Khen thưởng hoặc Kỹ luật
        public string Description { get; set; } // Mô tả chi tiết
        public decimal Amount { get; set; } // Số tiền khen thưởng hoặc trừ lương (nếu có)
    }
}
