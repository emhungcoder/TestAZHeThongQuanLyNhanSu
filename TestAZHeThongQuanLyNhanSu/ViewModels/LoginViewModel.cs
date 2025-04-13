﻿using System.ComponentModel.DataAnnotations;

namespace TestAZHeThongQuanLyNhanSu.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Ghi nhớ")]
        public bool RememberMe { get; set; }
    }
}
