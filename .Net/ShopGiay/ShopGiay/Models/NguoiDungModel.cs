using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopGiay.Models
{
    public class NguoiDungModel
    {
        [Required(ErrorMessage ="Vui lòng nhập tài khoản!")]
        public string TaiKhoan { get; set; }

        [StringLength(50, MinimumLength = 6)]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        public string MatKhau { get; set; }

        [Required]
        public string HoTen { get; set; }

        [Required]
        public string DiaChi { get; set; }

        [Required]
        [Phone(ErrorMessage = "Nhập đúng số điện thoại!")]
        public string PhoneNo { get; set; }
        public string SoDienThoai { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

    }
}