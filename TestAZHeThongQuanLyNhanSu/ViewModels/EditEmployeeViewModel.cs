namespace TestAZHeThongQuanLyNhanSu.ViewModels
{
    public class EditEmployeeViewModel
    {
        public string Id { get; set; }

   
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public int PositionId { get; set; }


        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }

}
