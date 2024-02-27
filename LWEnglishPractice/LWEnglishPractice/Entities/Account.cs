using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLySanXuat.Entities
{
    public partial class Account
    {

        [Required(ErrorMessage = "Vui lòng cung cấp email!")]
        [EmailAddress]
    
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng cung cấp mật khẩu!")]
        [StringLength(255, ErrorMessage = "Thông tin cung cấp quá dài!")]
        public string Password { get; set; }
        public bool KeepLoggedIn { get; set; }
        
    }
}
